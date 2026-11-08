using System.Drawing.Printing;

namespace AssetTracking.Reports;

/// <summary>جزء من التقرير: عنوان فرعي + جدول بيانات.</summary>
public sealed class ReportSection(string title, DataTable table, bool showCount = true)
{
    public string Title { get; } = title;
    public DataTable Table { get; } = table;
    public bool ShowCount { get; } = showCount;
}

/// <summary>تقرير جاهز للطباعة.</summary>
public sealed class ReportResult(string title, IEnumerable<ReportSection> sections, string? subtitle = null, string[]? signatures = null)
{
    public string Title { get; } = title;
    public string? Subtitle { get; } = subtitle;
    public List<ReportSection> Sections { get; } = sections.ToList();
    public string[] Signatures { get; } = signatures ?? new[] { "أمين المخزن", "المدير" };
}

/// <summary>
/// طباعة التقارير من اليمين لليسار مع ترويسة المؤسسة، وتكرار رأس الجدول في كل صفحة،
/// وترقيم الصفحات، وخانات التوقيع في النهاية. يعرض معاينة قبل الطباعة.
/// </summary>
public sealed class ReportPrinter
{
    private readonly ReportResult _report;

    private static readonly Font OrgFont = new(Theme.FontName, 13F, FontStyle.Bold);
    private static readonly Font TitleFont = new(Theme.FontName, 15F, FontStyle.Bold);
    private static readonly Font SubFont = new(Theme.FontName, 10F);
    private static readonly Font SectionFont = new(Theme.FontName, 11F, FontStyle.Bold);
    private static readonly Font HeaderFont = new(Theme.FontName, 9F, FontStyle.Bold);
    private static readonly Font CellFont = new(Theme.FontName, 9F);
    private static readonly Font FooterFont = new(Theme.FontName, 8F);

    private const float FooterHeight = 26f;

    // حالة الطباعة بين الصفحات
    private int _section, _row, _page;
    private bool _sectionTitleDone, _countDone, _signaturesDone;
    private List<DataColumn>? _cols;
    private float[]? _widths;

    public ReportPrinter(ReportResult report) => _report = report;

    public static void Preview(ReportResult report, IWin32Window? owner = null) => new ReportPrinter(report).ShowPreview(owner);

    private PrintDocument CreateDocument(string? printerName = null)
    {
        var doc = new PrintDocument { DocumentName = _report.Title };
        if (printerName != null) doc.PrinterSettings.PrinterName = printerName;
        doc.DefaultPageSettings.Landscape = _report.Sections.Any(s => Ui.VisibleColumns(s.Table).Count > 7);
        doc.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
        doc.BeginPrint += (_, _) => Reset();
        doc.PrintPage += PrintPage;
        return doc;
    }

    public void ShowPreview(IWin32Window? owner)
    {
        try
        {
            using var doc = CreateDocument();
            using var dlg = new PrintPreviewDialog
            {
                Document = doc,
                Text = "معاينة الطباعة - " + _report.Title,
                WindowState = FormWindowState.Maximized,
                ShowIcon = false,
                UseAntiAlias = true
            };
            dlg.ShowDialog(owner);
        }
        catch (InvalidPrinterException)
        {
            Ui.Warn("لا توجد طابعة معرّفة على الجهاز.\nقم بتثبيت طابعة أو فعّل \"Microsoft Print to PDF\" من إعدادات Windows.");
        }
    }

    /// <summary>حفظ التقرير كملف PDF عبر طابعة Windows المدمجة "Microsoft Print to PDF".</summary>
    public static void SavePdf(ReportResult report, IWin32Window? owner = null)
    {
        const string pdfPrinter = "Microsoft Print to PDF";
        using var dlg = new SaveFileDialog { Filter = "ملف PDF|*.pdf", FileName = report.Title + ".pdf" };
        if (dlg.ShowDialog(owner) != DialogResult.OK) return;

        using var doc = new ReportPrinter(report).CreateDocument(pdfPrinter);
        if (!doc.PrinterSettings.IsValid)
            throw new AppException("الطابعة \"Microsoft Print to PDF\" غير مفعّلة على هذا الجهاز. فعّلها من إعدادات Windows أو استخدم الطباعة.");
        doc.PrinterSettings.PrintToFile = true;
        doc.PrinterSettings.PrintFileName = dlg.FileName;
        doc.PrintController = new StandardPrintController();
        doc.Print();
        Ui.Info("تم حفظ التقرير:\n" + dlg.FileName);
    }

    private void Reset()
    {
        _section = _row = _page = 0;
        _sectionTitleDone = _countDone = _signaturesDone = false;
        _cols = null;
        _widths = null;
    }

    private static StringFormat Format(StringAlignment align = StringAlignment.Center) => new(StringFormatFlags.DirectionRightToLeft | StringFormatFlags.NoWrap)
    {
        Alignment = align,
        LineAlignment = StringAlignment.Center,
        Trimming = StringTrimming.EllipsisCharacter
    };

    private void PrintPage(object? sender, PrintPageEventArgs e)
    {
        var g = e.Graphics!;
        var b = e.MarginBounds;
        float bottom = b.Bottom - FooterHeight;
        _page++;

        float y = DrawPageHeader(g, b);

        while (_section < _report.Sections.Count)
        {
            var s = _report.Sections[_section];
            if (_cols == null)
            {
                _cols = Ui.VisibleColumns(s.Table);
                _widths = ComputeWidths(g, s.Table, _cols, b.Width);
            }

            // عنوان القسم
            if (!_sectionTitleDone)
            {
                if (y + 80 > bottom && y > b.Top + 120) { NextPage(e, g, b); return; }
                if (!string.IsNullOrEmpty(s.Title))
                {
                    g.DrawString(s.Title, SectionFont, Brushes.Black, new RectangleF(b.Left, y, b.Width, 24), Format(StringAlignment.Near));
                    y += 28;
                }
                _sectionTitleDone = true;
            }

            float rowH = CellFont.GetHeight(g) + 10;

            // رأس الجدول (يتكرر في كل صفحة)
            if (_row < s.Table.Rows.Count || (_row == 0 && !_countDone))
            {
                y = DrawRow(g, b, y, _cols.Select(c => c.ColumnName).ToArray(), HeaderFont, header: true);
            }

            if (s.Table.Rows.Count == 0 && _row == 0 && !_countDone)
            {
                g.DrawRectangle(Pens.Gray, b.Left, y, b.Width, rowH);
                g.DrawString("لا توجد بيانات", CellFont, Brushes.Gray, new RectangleF(b.Left, y, b.Width, rowH), Format());
                y += rowH;
            }

            while (_row < s.Table.Rows.Count)
            {
                if (y + rowH > bottom) { NextPage(e, g, b); return; }
                var r = s.Table.Rows[_row];
                y = DrawRow(g, b, y, _cols.Select(c => Ui.Format(r[c], c)).ToArray(), CellFont, header: false, alt: _row % 2 == 1);
                _row++;
            }

            if (s.ShowCount && !_countDone)
            {
                if (y + 24 > bottom) { NextPage(e, g, b); return; }
                g.DrawString($"عدد السجلات: {s.Table.Rows.Count}", SubFont, Brushes.Black,
                    new RectangleF(b.Left, y + 4, b.Width, 20), Format(StringAlignment.Near));
                y += 24;
            }
            _countDone = true;
            y += 14;

            // الانتقال للقسم التالي
            _section++;
            _row = 0;
            _cols = null;
            _sectionTitleDone = false;
            _countDone = false;
        }

        if (_report.Signatures.Length > 0 && !_signaturesDone)
        {
            if (y + 90 > bottom) { NextPage(e, g, b); return; }
            DrawSignatures(g, b, y + 20);
            _signaturesDone = true;
        }

        DrawFooter(g, b);
        e.HasMorePages = false;
    }

    private void NextPage(PrintPageEventArgs e, Graphics g, Rectangle b)
    {
        DrawFooter(g, b);
        e.HasMorePages = true;
    }

    private float DrawPageHeader(Graphics g, Rectangle b)
    {
        float y = b.Top;
        var center = Format();
        g.DrawString(AppSettings.OrganizationName, OrgFont, Brushes.Black, new RectangleF(b.Left, y, b.Width, 24), center);
        y += 24;
        g.DrawString(AppSettings.DepartmentName, SubFont, Brushes.Black, new RectangleF(b.Left, y, b.Width, 20), center);
        y += 24;
        g.DrawString(_report.Title, TitleFont, Brushes.Black, new RectangleF(b.Left, y, b.Width, 28), center);
        y += 30;
        if (!string.IsNullOrEmpty(_report.Subtitle))
        {
            g.DrawString(_report.Subtitle, SubFont, Brushes.DimGray, new RectangleF(b.Left, y, b.Width, 20), center);
            y += 22;
        }

        string meta = $"تاريخ الطباعة: {DateTime.Now:yyyy/MM/dd HH:mm}";
        if (Session.Current != null) meta += $"     المستخدم: {Session.Current.DisplayName}";
        g.DrawString(meta, FooterFont, Brushes.DimGray, new RectangleF(b.Left, y, b.Width, 18), Format(StringAlignment.Near));
        y += 20;
        using var pen = new Pen(Color.FromArgb(30, 77, 120), 2);
        g.DrawLine(pen, b.Left, y, b.Right, y);
        return y + 10;
    }

    private void DrawFooter(Graphics g, Rectangle b)
    {
        float y = b.Bottom - FooterHeight + 6;
        g.DrawLine(Pens.Silver, b.Left, y, b.Right, y);
        g.DrawString($"صفحة {_page}", FooterFont, Brushes.DimGray, new RectangleF(b.Left, y + 2, b.Width, 18), Format());
        g.DrawString("نظام حصر الأصول وتتبع العهد", FooterFont, Brushes.DimGray, new RectangleF(b.Left, y + 2, b.Width, 18), Format(StringAlignment.Far));
    }

    private float DrawRow(Graphics g, Rectangle b, float y, string[] values, Font font, bool header, bool alt = false)
    {
        float h = font.GetHeight(g) + 10;
        float x = b.Right;
        var fmt = Format();
        using var headerBrush = new SolidBrush(Color.FromArgb(222, 231, 241));
        using var altBrush = new SolidBrush(Color.FromArgb(247, 249, 251));
        for (int i = 0; i < values.Length; i++)
        {
            float w = _widths![i];
            var rect = new RectangleF(x - w, y, w, h);
            if (header) g.FillRectangle(headerBrush, rect);
            else if (alt) g.FillRectangle(altBrush, rect);
            g.DrawRectangle(Pens.Gray, rect.X, rect.Y, rect.Width, rect.Height);
            g.DrawString(values[i], font, Brushes.Black, RectangleF.Inflate(rect, -3, 0), fmt);
            x -= w;
        }
        return y + h;
    }

    /// <summary>حساب عرض الأعمدة حسب محتواها ثم ملاءمتها لعرض الصفحة.</summary>
    private static float[] ComputeWidths(Graphics g, DataTable t, List<DataColumn> cols, float pageWidth)
    {
        if (cols.Count == 0) return Array.Empty<float>();
        var widths = new float[cols.Count];
        int sample = Math.Min(t.Rows.Count, 300);
        for (int i = 0; i < cols.Count; i++)
        {
            float w = g.MeasureString(cols[i].ColumnName, HeaderFont).Width;
            for (int r = 0; r < sample; r++)
                w = Math.Max(w, g.MeasureString(Ui.Format(t.Rows[r][cols[i]], cols[i]), CellFont).Width);
            widths[i] = Math.Min(w + 14, pageWidth * 0.4f);
        }
        float total = widths.Sum();
        float scale = pageWidth / total;
        for (int i = 0; i < widths.Length; i++) widths[i] *= scale;
        return widths;
    }

    private void DrawSignatures(Graphics g, Rectangle b, float y)
    {
        int n = _report.Signatures.Length;
        float w = b.Width / (float)n;
        var fmt = Format();
        for (int i = 0; i < n; i++)
        {
            float x = b.Right - (i + 1) * w;
            g.DrawString(_report.Signatures[i], SectionFont, Brushes.Black, new RectangleF(x, y, w, 22), fmt);
            g.DrawString("الاسم: ....................................", SubFont, Brushes.Black, new RectangleF(x, y + 28, w, 20), fmt);
            g.DrawString("التوقيع: ..................................", SubFont, Brushes.Black, new RectangleF(x, y + 52, w, 20), fmt);
        }
    }
}
