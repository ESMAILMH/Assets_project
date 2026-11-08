/* =====================================================================
   بيانات تجريبية كاملة لنظام حصر الأصول وتتبع العهد
   تُشغَّل بعد إنشاء قاعدة AssetsDB (السكربت AssetsDB_Full.sql أو 01_AssetsDB.sql)
   افتحه في SSMS من File > Open > File ثم اضغط Execute (F5)

   حسابات الدخول التجريبية:
     admin / Admin@123   (مدير)
     store / Store@123   (أمين مخزن)
     user  / User@123    (موظف)
   ===================================================================== */
GO
USE AssetsDB;
GO
-- لا تُضاف البيانات مرتين
IF DB_NAME() <> N'AssetsDB' OR EXISTS (SELECT 1 FROM dbo.Asset)
BEGIN
    RAISERROR(N'القاعدة AssetsDB غير موجودة أو تحتوي أصولاً بالفعل. لم تُضف البيانات التجريبية.', 16, 1);
    SET NOEXEC ON;
END
GO
SET NOCOUNT ON;
BEGIN TRAN;

/* ---------- الأقسام والمواقع ---------- */
INSERT dbo.Department (Name) VALUES
 (N'قسم تقنية المعلومات'),
 (N'الشؤون الإدارية'),
 (N'الشؤون المالية'),
 (N'المخزن الرئيسي'),
 (N'قسم الهندسة المدنية');
INSERT dbo.Location (Name, DepartmentId) VALUES
 (N'معمل الحاسوب 1', (SELECT DepartmentId FROM dbo.Department WHERE Name = N'قسم تقنية المعلومات')),
 (N'معمل الحاسوب 2', (SELECT DepartmentId FROM dbo.Department WHERE Name = N'قسم تقنية المعلومات')),
 (N'مكتب رئيس القسم', (SELECT DepartmentId FROM dbo.Department WHERE Name = N'قسم تقنية المعلومات')),
 (N'مكتب المدير', (SELECT DepartmentId FROM dbo.Department WHERE Name = N'الشؤون الإدارية')),
 (N'مكتب شؤون الطلبة', (SELECT DepartmentId FROM dbo.Department WHERE Name = N'الشؤون الإدارية')),
 (N'مكتب المحاسبة', (SELECT DepartmentId FROM dbo.Department WHERE Name = N'الشؤون المالية')),
 (N'المخزن', (SELECT DepartmentId FROM dbo.Department WHERE Name = N'المخزن الرئيسي')),
 (N'معمل المواد', (SELECT DepartmentId FROM dbo.Department WHERE Name = N'قسم الهندسة المدنية'));

/* ---------- الأشخاص ---------- */
INSERT dbo.Person (FullName, EmployeeNo, DepartmentId, Phone) VALUES
 (N'أحمد محمد علي', N'EMP-001', (SELECT DepartmentId FROM dbo.Department WHERE Name = N'قسم تقنية المعلومات'), N'0911234567'),
 (N'خالد مصطفى الترهوني', N'EMP-002', (SELECT DepartmentId FROM dbo.Department WHERE Name = N'المخزن الرئيسي'), N'0921234567'),
 (N'سالم عمر خليفة', N'EMP-003', (SELECT DepartmentId FROM dbo.Department WHERE Name = N'الشؤون الإدارية'), N'0913456789'),
 (N'فاطمة إبراهيم الصغير', N'EMP-004', (SELECT DepartmentId FROM dbo.Department WHERE Name = N'الشؤون المالية'), N'0925678901'),
 (N'عبدالله سعيد المبروك', N'EMP-005', (SELECT DepartmentId FROM dbo.Department WHERE Name = N'الشؤون الإدارية'), N'0917890123'),
 (N'محمود الهادي بن علي', N'EMP-006', (SELECT DepartmentId FROM dbo.Department WHERE Name = N'قسم الهندسة المدنية'), N'0928901234'),
 (N'مريم عبدالسلام', N'EMP-007', (SELECT DepartmentId FROM dbo.Department WHERE Name = N'قسم تقنية المعلومات'), NULL),
 (N'يوسف ناصر القماطي', N'EMP-008', (SELECT DepartmentId FROM dbo.Department WHERE Name = N'قسم الهندسة المدنية'), N'0919012345');

/* ---------- المستخدمون (كلمات المرور مشفّرة PBKDF2-SHA256 مثل التطبيق تماماً) ---------- */
IF NOT EXISTS (SELECT 1 FROM dbo.[User] WHERE Username = N'admin')
    INSERT dbo.[User] (Username, PasswordHash, PasswordSalt, Role, PersonId) VALUES
    (N'admin', 0x85D79C02548009361B88C743130F542C6802E4ACA5688F3C76AFD2D1E46531AA, 0xD77EE0CEB38E2AA690A6987C42E14AF6, N'Manager', NULL);
IF NOT EXISTS (SELECT 1 FROM dbo.[User] WHERE Username = N'store')
    INSERT dbo.[User] (Username, PasswordHash, PasswordSalt, Role, PersonId) VALUES
    (N'store', 0x4699A679223869E44C749584A80DAFA3A76129E1DAE92921C142EA809D6C5837, 0xDBC840404C8D8AF5CC46D3567C3B075E, N'StoreKeeper', (SELECT PersonId FROM dbo.Person WHERE EmployeeNo = N'EMP-002'));
IF NOT EXISTS (SELECT 1 FROM dbo.[User] WHERE Username = N'user')
    INSERT dbo.[User] (Username, PasswordHash, PasswordSalt, Role, PersonId) VALUES
    (N'user', 0xC8FA1D791771AF8D4A13F49995BBAE87163B43A7A8411BB2F010DD3C7A42B6EC, 0xCDBB93537F89F2458A455D8EC3D7579D, N'Employee', (SELECT PersonId FROM dbo.Person WHERE EmployeeNo = N'EMP-001'));
DECLARE @mgr INT = (SELECT TOP 1 UserId FROM dbo.[User] WHERE Role = N'Manager' ORDER BY UserId);
DECLARE @store INT = (SELECT UserId FROM dbo.[User] WHERE Username = N'store');

/* ---------- الأصول (تواريخ متنوعة لإظهار الإهلاك والتنبيهات) ---------- */
INSERT dbo.Asset (SerialNo, Name, CategoryId, Model, PurchaseDate, InServiceDate, Cost, LifeYears, SalvageValue, LocationId, Status) VALUES
 (N'PC-001', N'حاسوب مكتبي', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'أجهزة حاسوب'), N'Dell OptiPlex 7090', '2024-02-01', '2024-02-10', 2400, 5, 0, (SELECT LocationId FROM dbo.Location WHERE Name = N'معمل الحاسوب 1'), N'InCustody'),
 (N'PC-002', N'حاسوب مكتبي', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'أجهزة حاسوب'), N'Dell OptiPlex 7090', '2024-02-01', '2024-02-10', 2400, 5, 0, (SELECT LocationId FROM dbo.Location WHERE Name = N'معمل الحاسوب 1'), N'Available'),
 (N'PC-003', N'حاسوب مكتبي', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'أجهزة حاسوب'), N'HP ProDesk 400', '2022-06-01', '2022-06-01', 2100, 5, 0, (SELECT LocationId FROM dbo.Location WHERE Name = N'معمل الحاسوب 2'), N'Available'),
 (N'PC-004', N'حاسوب مكتبي', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'أجهزة حاسوب'), N'Lenovo ThinkCentre M70', '2020-05-01', '2020-05-01', 1600, 5, 0, (SELECT LocationId FROM dbo.Location WHERE Name = N'معمل الحاسوب 2'), N'Available'),
 (N'PC-005', N'حاسوب محمول', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'أجهزة حاسوب'), N'HP ProBook 450', '2025-03-01', '2025-03-05', 3200, 5, 200, (SELECT LocationId FROM dbo.Location WHERE Name = N'مكتب رئيس القسم'), N'InCustody'),
 (N'PC-006', N'حاسوب محمول', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'أجهزة حاسوب'), N'Dell Latitude 5420', '2023-09-01', '2023-09-01', 3500, 5, 300, (SELECT LocationId FROM dbo.Location WHERE Name = N'مكتب المدير'), N'InCustody'),
 (N'PC-007', N'حاسوب محمول', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'أجهزة حاسوب'), N'Lenovo ThinkPad E14', '2021-09-15', '2021-09-15', 2800, 5, 0, (SELECT LocationId FROM dbo.Location WHERE Name = N'مكتب المحاسبة'), N'InCustody'),
 (N'PC-008', N'حاسوب مكتبي', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'أجهزة حاسوب'), N'Acer Veriton', '2018-03-01', '2018-03-01', 1200, 5, 0, (SELECT LocationId FROM dbo.Location WHERE Name = N'المخزن'), N'Disposed'),
 (N'PR-001', N'طابعة ليزر', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'طابعات وملحقات'), N'HP LaserJet M404', '2023-01-05', '2023-01-10', 950, 4, 0, (SELECT LocationId FROM dbo.Location WHERE Name = N'مكتب شؤون الطلبة'), N'InCustody'),
 (N'PR-002', N'طابعة ملونة', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'طابعات وملحقات'), N'Canon i-SENSYS MF655', '2024-07-01', '2024-07-01', 1400, 4, 50, (SELECT LocationId FROM dbo.Location WHERE Name = N'مكتب المحاسبة'), N'Available'),
 (N'PR-003', N'ماسح ضوئي', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'طابعات وملحقات'), N'Epson DS-530', '2025-01-20', '2025-01-20', 1100, 4, 0, (SELECT LocationId FROM dbo.Location WHERE Name = N'مكتب شؤون الطلبة'), N'Available'),
 (N'FN-001', N'مكتب مدير خشبي', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'أثاث مكتبي'), NULL, '2020-01-15', '2020-01-15', 1500, 10, 100, (SELECT LocationId FROM dbo.Location WHERE Name = N'مكتب المدير'), N'Available'),
 (N'FN-002', N'كرسي مكتب دوار', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'أثاث مكتبي'), NULL, '2023-03-01', '2023-03-01', 350, 10, 0, (SELECT LocationId FROM dbo.Location WHERE Name = N'مكتب رئيس القسم'), N'InCustody'),
 (N'FN-003', N'خزانة ملفات حديدية', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'أثاث مكتبي'), NULL, '2019-09-01', '2019-09-01', 600, 10, 50, (SELECT LocationId FROM dbo.Location WHERE Name = N'مكتب المحاسبة'), N'Available'),
 (N'FN-004', N'طاولة اجتماعات', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'أثاث مكتبي'), NULL, '2022-11-01', '2022-11-01', 2200, 10, 200, (SELECT LocationId FROM dbo.Location WHERE Name = N'مكتب المدير'), N'Available'),
 (N'FN-005', N'كرسي مكتب قديم', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'أثاث مكتبي'), NULL, '2015-01-01', '2015-01-01', 250, 10, 0, (SELECT LocationId FROM dbo.Location WHERE Name = N'المخزن'), N'Archived'),
 (N'EL-001', N'جهاز عرض (بروجكتر)', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'أجهزة كهربائية'), N'Epson EB-X51', '2024-09-01', '2024-09-01', 1800, 7, 0, (SELECT LocationId FROM dbo.Location WHERE Name = N'معمل الحاسوب 1'), N'Available'),
 (N'EL-002', N'شاشة عرض تفاعلية', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'أجهزة كهربائية'), N'Samsung Flip 55', '2025-06-01', '2025-06-01', 9500, 7, 500, (SELECT LocationId FROM dbo.Location WHERE Name = N'معمل الحاسوب 2'), N'Available'),
 (N'EL-003', N'مكيف هواء', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'أجهزة كهربائية'), N'LG 24000 BTU', '2019-06-01', '2019-06-01', 3200, 7, 200, (SELECT LocationId FROM dbo.Location WHERE Name = N'معمل الحاسوب 1'), N'Available'),
 (N'EL-004', N'آلة تصوير مستندات', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'أجهزة كهربائية'), N'Ricoh MP 2014', '2021-12-01', '2021-12-01', 4800, 7, 300, (SELECT LocationId FROM dbo.Location WHERE Name = N'مكتب شؤون الطلبة'), N'Available'),
 (N'EQ-001', N'جهاز اختبار ضغط الخرسانة', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'معدات ومختبرات'), N'Controls 50-C46', '2022-02-01', '2022-02-15', 18000, 8, 1000, (SELECT LocationId FROM dbo.Location WHERE Name = N'معمل المواد'), N'InCustody'),
 (N'EQ-002', N'ميزان رقمي دقيق', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'معدات ومختبرات'), N'Ohaus Scout', '2024-04-01', '2024-04-01', 2600, 8, 0, (SELECT LocationId FROM dbo.Location WHERE Name = N'معمل المواد'), N'Available'),
 (N'EQ-003', N'جهاز مساحة (توتال ستيشن)', (SELECT CategoryId FROM dbo.AssetCategory WHERE Name = N'معدات ومختبرات'), N'Leica TS07', '2023-10-01', '2023-10-01', 25000, 8, 2000, (SELECT LocationId FROM dbo.Location WHERE Name = N'معمل المواد'), N'InCustody');

/* ---------- العهد: حركات منتهية (سجل تاريخي) ثم العهد المفتوحة حالياً ---------- */
INSERT dbo.AssetCustody (AssetId, PersonId, HandoverDate, ConditionAtHandover, ReturnDate, ConditionAtReturn, Notes, CreatedBy) VALUES
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PC-007'), (SELECT PersonId FROM dbo.Person WHERE EmployeeNo = N'EMP-001'), '2021-09-20', N'جديد', '2024-01-10', N'سليم', N'نُقل لاحقاً إلى الشؤون المالية', @store),
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PC-002'), (SELECT PersonId FROM dbo.Person WHERE EmployeeNo = N'EMP-007'), '2024-03-01', N'جديد', '2026-08-25', N'يحتاج صيانة', NULL, @store),
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PC-008'), (SELECT PersonId FROM dbo.Person WHERE EmployeeNo = N'EMP-008'), '2018-03-05', N'جديد', '2025-12-01', N'تالف', N'الجهاز لا يعمل', @store),
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'EL-001'), (SELECT PersonId FROM dbo.Person WHERE EmployeeNo = N'EMP-001'), '2024-09-05', N'جديد', '2025-01-15', N'سليم', N'استُخدم لدورة تدريبية', @store),
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PC-005'), (SELECT PersonId FROM dbo.Person WHERE EmployeeNo = N'EMP-001'), '2025-03-10', N'سليم', NULL, NULL, NULL, @store),
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PC-006'), (SELECT PersonId FROM dbo.Person WHERE EmployeeNo = N'EMP-005'), '2023-09-05', N'جديد', NULL, NULL, N'للاستخدام في مكتب المدير', @store),
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PC-007'), (SELECT PersonId FROM dbo.Person WHERE EmployeeNo = N'EMP-004'), '2024-01-15', N'سليم', NULL, NULL, NULL, @store),
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PR-001'), (SELECT PersonId FROM dbo.Person WHERE EmployeeNo = N'EMP-003'), '2023-02-01', N'جديد', NULL, NULL, NULL, @store),
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'EQ-001'), (SELECT PersonId FROM dbo.Person WHERE EmployeeNo = N'EMP-006'), '2022-03-01', N'جديد', NULL, NULL, N'عهدة معمل المواد', @store),
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'EQ-003'), (SELECT PersonId FROM dbo.Person WHERE EmployeeNo = N'EMP-006'), '2023-10-10', N'جديد', NULL, NULL, N'يُعاد بعد كل رحلة ميدانية', @store),
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'FN-002'), (SELECT PersonId FROM dbo.Person WHERE EmployeeNo = N'EMP-001'), '2023-03-05', N'جديد', NULL, NULL, NULL, @store),
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PC-001'), (SELECT PersonId FROM dbo.Person WHERE EmployeeNo = N'EMP-007'), '2026-09-01', N'سليم', NULL, NULL, NULL, @store);

/* ---------- الصيانة ---------- */
INSERT dbo.MaintenanceRecord (AssetId, MaintenanceDate, Type, Description, PerformedBy, Cost, CreatedBy) VALUES
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PC-002'), '2026-09-02', N'إصلاح عطل', N'استبدال وحدة التغذية بعد الاستلام', N'ورشة الكلية', 150, @store),
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'EL-003'), '2025-07-10', N'صيانة وقائية', N'تنظيف الفلاتر وشحن الغاز', N'شركة التبريد الحديثة', 350, @store),
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'EL-003'), '2026-07-08', N'إصلاح عطل', N'إصلاح المروحة الخارجية بعد رفض التخريد', N'شركة التبريد الحديثة', 480, @store),
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'EL-004'), '2026-02-14', N'استبدال قطعة', N'استبدال وحدة الطباعة (الدرام)', N'الوكيل المعتمد', 620, @store),
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PR-001'), '2025-11-03', N'إصلاح عطل', N'إزالة ورق عالق وتنظيف البكرات', N'ورشة الكلية', NULL, @store),
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'EQ-001'), '2026-05-20', N'صيانة وقائية', N'معايرة الجهاز السنوية', N'مختبر المعايرة الوطني', 900, @store);

/* ---------- التخريد: معتمد، مرفوض، وطلب بانتظار المدير ---------- */
INSERT dbo.Disposal (AssetId, ProposedDate, Reason, ProposedBy, Status, ApprovedBy, ApprovedDate, DocumentNo) VALUES
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PC-008'), '2025-12-05', N'تالف عند الاستلام وانتهى عمره الافتراضي', @store, N'Approved', @mgr, '2025-12-20', N'م-2025-014'),
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'EL-003'), '2026-07-01', N'انتهاء العمر الافتراضي', @store, N'Rejected', @mgr, '2026-07-05', NULL),
 ((SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PC-004'), '2026-10-20', N'انتهاء العمر الافتراضي وبطء شديد في الأداء', @store, N'Proposed', NULL, NULL, NULL);

/* ---------- الجرد: جلسة مغلقة لقسم تقنية المعلومات، وجلسة مفتوحة لمعمل المواد ---------- */
INSERT dbo.InventorySession (SessionDate, DepartmentId, LocationId, Status, CreatedBy)
VALUES ('2026-06-15', (SELECT DepartmentId FROM dbo.Department WHERE Name = N'قسم تقنية المعلومات'), NULL, N'Closed', @store);
DECLARE @s1 INT = SCOPE_IDENTITY();
INSERT dbo.InventoryLine (SessionId, AssetId, Result) VALUES
 (@s1, (SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PC-001'), N'Found'),
 (@s1, (SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PC-002'), N'Found'),
 (@s1, (SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PC-003'), N'Found'),
 (@s1, (SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PC-004'), N'Found'),
 (@s1, (SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PC-005'), N'Found'),
 (@s1, (SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'FN-002'), N'Found'),
 (@s1, (SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'EL-001'), N'Found'),
 (@s1, (SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'EL-002'), N'Missing'),
 (@s1, (SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'EL-003'), N'Found'),
 (@s1, (SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PR-003'), N'DifferentLocation');
INSERT dbo.InventorySession (SessionDate, DepartmentId, LocationId, Status, CreatedBy)
VALUES (CAST(GETDATE() AS DATE), (SELECT DepartmentId FROM dbo.Department WHERE Name = N'قسم الهندسة المدنية'), (SELECT LocationId FROM dbo.Location WHERE Name = N'معمل المواد'), N'Open', @store);

/* ---------- سجل العمليات (أمثلة) ---------- */
INSERT dbo.AuditLog (UserId, Action, EntityName, EntityId, Details, CreatedAt) VALUES
 (@store, N'ImportAssets', N'Asset', NULL, N'بيانات تجريبية: 23 أصل', DATEADD(DAY, -30, SYSDATETIME())),
 (@store, N'Handover', N'Asset', (SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PC-001'), N'PersonId=' + CAST((SELECT PersonId FROM dbo.Person WHERE EmployeeNo = N'EMP-007') AS NVARCHAR(10)), DATEADD(DAY, -20, SYSDATETIME())),
 (@store, N'Receive', N'Asset', (SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PC-002'), N'يحتاج صيانة', DATEADD(DAY, -15, SYSDATETIME())),
 (@store, N'AddMaintenance', N'Asset', (SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PC-002'), N'إصلاح عطل', DATEADD(DAY, -14, SYSDATETIME())),
 (@store, N'ProposeDisposal', N'Asset', (SELECT AssetId FROM dbo.Asset WHERE SerialNo = N'PC-004'), N'انتهاء العمر الافتراضي', DATEADD(DAY, -10, SYSDATETIME())),
 (@mgr, N'Login', N'User', @mgr, NULL, DATEADD(HOUR, -2, SYSDATETIME()));

COMMIT;
GO
SET NOEXEC OFF;
PRINT N'تمت إضافة البيانات التجريبية بنجاح. سجّل الدخول بـ admin / Admin@123';
GO