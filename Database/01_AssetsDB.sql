/* =====================================================================
   Assets and Custody Tracking System - SQL Server schema
   Run in SSMS. Save/open this file as UTF-8 (Arabic seed data).
   ===================================================================== */
USE master;
GO
IF DB_ID(N'AssetsDB') IS NULL
    CREATE DATABASE AssetsDB COLLATE Arabic_CI_AS;
GO
USE AssetsDB;
GO
-- حماية: إذا لم تُنشأ القاعدة لأي سبب، يتوقف السكربت بدل إنشاء الجداول في قاعدة أخرى (مثل master)
IF DB_NAME() <> N'AssetsDB'
BEGIN
    RAISERROR(N'لم يتم إنشاء قاعدة AssetsDB أو الانتقال إليها. توقف التنفيذ.', 16, 1);
    SET NOEXEC ON;
END
GO

/* ---------- 1. Lookup / master tables ---------- */
CREATE TABLE dbo.Department (
    DepartmentId INT IDENTITY(1,1) CONSTRAINT PK_Department PRIMARY KEY,
    Name         NVARCHAR(100) NOT NULL CONSTRAINT UQ_Department_Name UNIQUE,
    IsActive     BIT NOT NULL CONSTRAINT DF_Department_Active DEFAULT 1
);

CREATE TABLE dbo.Location (
    LocationId   INT IDENTITY(1,1) CONSTRAINT PK_Location PRIMARY KEY,
    Name         NVARCHAR(100) NOT NULL,
    DepartmentId INT NOT NULL CONSTRAINT FK_Location_Department REFERENCES dbo.Department(DepartmentId),
    IsActive     BIT NOT NULL CONSTRAINT DF_Location_Active DEFAULT 1,
    CONSTRAINT UQ_Location UNIQUE (DepartmentId, Name)
);

CREATE TABLE dbo.Person (
    PersonId     INT IDENTITY(1,1) CONSTRAINT PK_Person PRIMARY KEY,
    FullName     NVARCHAR(150) NOT NULL,
    EmployeeNo   NVARCHAR(30)  NULL,
    DepartmentId INT NOT NULL CONSTRAINT FK_Person_Department REFERENCES dbo.Department(DepartmentId),
    Phone        NVARCHAR(30)  NULL,
    IsActive     BIT NOT NULL CONSTRAINT DF_Person_Active DEFAULT 1
);
-- EmployeeNo is unique only when it has a value
CREATE UNIQUE INDEX UX_Person_EmployeeNo ON dbo.Person(EmployeeNo) WHERE EmployeeNo IS NOT NULL;

CREATE TABLE dbo.[User] (
    UserId       INT IDENTITY(1,1) CONSTRAINT PK_User PRIMARY KEY,
    Username     NVARCHAR(50) NOT NULL CONSTRAINT UQ_User_Username UNIQUE,
    PasswordHash VARBINARY(64) NOT NULL,   -- PBKDF2 / SHA-256 computed in C#, never plain text
    PasswordSalt VARBINARY(32) NOT NULL,
    Role         NVARCHAR(20) NOT NULL
                 CONSTRAINT CK_User_Role CHECK (Role IN (N'Manager', N'StoreKeeper', N'Employee')),
    PersonId     INT NULL CONSTRAINT FK_User_Person REFERENCES dbo.Person(PersonId),
    IsActive     BIT NOT NULL CONSTRAINT DF_User_Active DEFAULT 1
);
-- a person has at most one login account
CREATE UNIQUE INDEX UX_User_PersonId ON dbo.[User](PersonId) WHERE PersonId IS NOT NULL;

CREATE TABLE dbo.AssetCategory (
    CategoryId       INT IDENTITY(1,1) CONSTRAINT PK_AssetCategory PRIMARY KEY,
    Name             NVARCHAR(100) NOT NULL CONSTRAINT UQ_AssetCategory_Name UNIQUE,
    DefaultLifeYears INT NOT NULL CONSTRAINT CK_Category_Life CHECK (DefaultLifeYears > 0)
);

/* ---------- 2. Assets ---------- */
CREATE TABLE dbo.Asset (
    AssetId       INT IDENTITY(1,1) CONSTRAINT PK_Asset PRIMARY KEY,
    SerialNo      NVARCHAR(50)  NOT NULL CONSTRAINT UQ_Asset_SerialNo UNIQUE,
    Name          NVARCHAR(150) NOT NULL,
    CategoryId    INT NOT NULL CONSTRAINT FK_Asset_Category REFERENCES dbo.AssetCategory(CategoryId),
    Model         NVARCHAR(100) NULL,
    PurchaseDate  DATE NULL,
    InServiceDate DATE NOT NULL,                          -- depreciation starts here
    Cost          DECIMAL(18,3) NOT NULL CONSTRAINT CK_Asset_Cost CHECK (Cost >= 0),
    LifeYears     INT NOT NULL CONSTRAINT CK_Asset_Life CHECK (LifeYears > 0),
    SalvageValue  DECIMAL(18,3) NOT NULL CONSTRAINT DF_Asset_Salvage DEFAULT 0,
    LocationId    INT NULL CONSTRAINT FK_Asset_Location REFERENCES dbo.Location(LocationId),
    Status        NVARCHAR(20) NOT NULL CONSTRAINT DF_Asset_Status DEFAULT N'Available'
                  CONSTRAINT CK_Asset_Status CHECK (Status IN (N'Available', N'InCustody', N'Disposed', N'Archived')),
    Image         VARBINARY(MAX) NULL,                    -- optional photo, stored in the database
    CreatedAt     DATETIME2 NOT NULL CONSTRAINT DF_Asset_Created DEFAULT SYSDATETIME(),
    CONSTRAINT CK_Asset_Salvage CHECK (SalvageValue >= 0 AND SalvageValue <= Cost),
    CONSTRAINT CK_Asset_ImageSize CHECK (Image IS NULL OR DATALENGTH(Image) <= 2097152) -- max 2 MB
);
CREATE INDEX IX_Asset_Name     ON dbo.Asset(Name);
CREATE INDEX IX_Asset_Status   ON dbo.Asset(Status) INCLUDE (CategoryId, LocationId);
CREATE INDEX IX_Asset_Category ON dbo.Asset(CategoryId);
CREATE INDEX IX_Asset_Location ON dbo.Asset(LocationId);

CREATE TABLE dbo.AssetCustody (
    CustodyId           INT IDENTITY(1,1) CONSTRAINT PK_AssetCustody PRIMARY KEY,
    AssetId             INT NOT NULL CONSTRAINT FK_Custody_Asset  REFERENCES dbo.Asset(AssetId),
    PersonId            INT NOT NULL CONSTRAINT FK_Custody_Person REFERENCES dbo.Person(PersonId),
    HandoverDate        DATE NOT NULL,
    ConditionAtHandover NVARCHAR(30) NOT NULL,
    ReturnDate          DATE NULL,
    ConditionAtReturn   NVARCHAR(30) NULL,
    Notes               NVARCHAR(300) NULL,
    CreatedBy           INT NOT NULL CONSTRAINT FK_Custody_User REFERENCES dbo.[User](UserId),
    CONSTRAINT CK_Custody_Dates CHECK (ReturnDate IS NULL OR ReturnDate >= HandoverDate)
);
-- BR-04: an asset can have only ONE open custody (ReturnDate IS NULL) at any time
CREATE UNIQUE INDEX UX_Custody_OneOpenPerAsset ON dbo.AssetCustody(AssetId) WHERE ReturnDate IS NULL;
CREATE INDEX IX_Custody_Person ON dbo.AssetCustody(PersonId) INCLUDE (AssetId, ReturnDate);

CREATE TABLE dbo.MaintenanceRecord (
    MaintenanceId   INT IDENTITY(1,1) CONSTRAINT PK_Maintenance PRIMARY KEY,
    AssetId         INT NOT NULL CONSTRAINT FK_Maintenance_Asset REFERENCES dbo.Asset(AssetId),
    MaintenanceDate DATE NOT NULL,
    Type            NVARCHAR(50)  NOT NULL,
    Description     NVARCHAR(500) NULL,
    PerformedBy     NVARCHAR(100) NULL,
    Cost            DECIMAL(18,3) NULL CONSTRAINT CK_Maintenance_Cost CHECK (Cost IS NULL OR Cost >= 0),
    CreatedBy       INT NOT NULL CONSTRAINT FK_Maintenance_User REFERENCES dbo.[User](UserId)
);
CREATE INDEX IX_Maintenance_Asset ON dbo.MaintenanceRecord(AssetId, MaintenanceDate DESC);

CREATE TABLE dbo.Disposal (
    DisposalId   INT IDENTITY(1,1) CONSTRAINT PK_Disposal PRIMARY KEY,
    AssetId      INT NOT NULL CONSTRAINT FK_Disposal_Asset REFERENCES dbo.Asset(AssetId),
    ProposedDate DATE NOT NULL CONSTRAINT DF_Disposal_Proposed DEFAULT CAST(SYSDATETIME() AS DATE),
    Reason       NVARCHAR(300) NOT NULL,
    ProposedBy   INT NOT NULL CONSTRAINT FK_Disposal_Proposer REFERENCES dbo.[User](UserId),
    Status       NVARCHAR(20) NOT NULL CONSTRAINT DF_Disposal_Status DEFAULT N'Proposed'
                 CONSTRAINT CK_Disposal_Status CHECK (Status IN (N'Proposed', N'Approved', N'Rejected')),
    ApprovedBy   INT NULL CONSTRAINT FK_Disposal_Approver REFERENCES dbo.[User](UserId),
    ApprovedDate DATE NULL,
    DocumentNo   NVARCHAR(50) NULL,
    CONSTRAINT CK_Disposal_Approval CHECK (Status <> N'Approved' OR (ApprovedBy IS NOT NULL AND ApprovedDate IS NOT NULL))
);
-- one live (not rejected) disposal per asset
CREATE UNIQUE INDEX UX_Disposal_OneLive ON dbo.Disposal(AssetId) WHERE Status <> N'Rejected';

/* ---------- 3. Inventory ---------- */
CREATE TABLE dbo.InventorySession (
    SessionId    INT IDENTITY(1,1) CONSTRAINT PK_InventorySession PRIMARY KEY,
    SessionDate  DATE NOT NULL CONSTRAINT DF_Session_Date DEFAULT CAST(SYSDATETIME() AS DATE),
    DepartmentId INT NULL CONSTRAINT FK_Session_Department REFERENCES dbo.Department(DepartmentId),
    LocationId   INT NULL CONSTRAINT FK_Session_Location   REFERENCES dbo.Location(LocationId),
    Status       NVARCHAR(10) NOT NULL CONSTRAINT DF_Session_Status DEFAULT N'Open'
                 CONSTRAINT CK_Session_Status CHECK (Status IN (N'Open', N'Closed')),
    CreatedBy    INT NOT NULL CONSTRAINT FK_Session_User REFERENCES dbo.[User](UserId)
);

CREATE TABLE dbo.InventoryLine (
    LineId    INT IDENTITY(1,1) CONSTRAINT PK_InventoryLine PRIMARY KEY,
    SessionId INT NOT NULL CONSTRAINT FK_Line_Session REFERENCES dbo.InventorySession(SessionId),
    AssetId   INT NOT NULL CONSTRAINT FK_Line_Asset   REFERENCES dbo.Asset(AssetId),
    Result    NVARCHAR(20) NOT NULL
              CONSTRAINT CK_Line_Result CHECK (Result IN (N'Found', N'Missing', N'Surplus', N'DifferentLocation')),
    CONSTRAINT UQ_Line UNIQUE (SessionId, AssetId)
);

/* ---------- 4. Audit log ---------- */
CREATE TABLE dbo.AuditLog (
    LogId      BIGINT IDENTITY(1,1) CONSTRAINT PK_AuditLog PRIMARY KEY,
    UserId     INT NOT NULL CONSTRAINT FK_Audit_User REFERENCES dbo.[User](UserId),
    Action     NVARCHAR(50)  NOT NULL,
    EntityName NVARCHAR(50)  NOT NULL,
    EntityId   INT NULL,
    Details    NVARCHAR(500) NULL,
    CreatedAt  DATETIME2 NOT NULL CONSTRAINT DF_Audit_Created DEFAULT SYSDATETIME()
);
CREATE INDEX IX_Audit_Created ON dbo.AuditLog(CreatedAt DESC);
GO

/* ---------- 5. Views: straight-line depreciation (computed, never stored) ---------- */
CREATE VIEW dbo.vw_AssetValuation AS
SELECT  a.AssetId, a.SerialNo, a.Name, a.CategoryId, a.LocationId, a.Status,
        a.Cost, a.SalvageValue, a.LifeYears, a.InServiceDate,
        x.MonthsElapsed,
        x.TotalMonths,
        CASE WHEN x.TotalMonths - x.MonthsElapsed < 0 THEN 0
             ELSE x.TotalMonths - x.MonthsElapsed END                         AS RemainingMonths,
        CAST((a.Cost - a.SalvageValue) / x.TotalMonths
             * CASE WHEN x.MonthsElapsed > x.TotalMonths THEN x.TotalMonths
                    WHEN x.MonthsElapsed < 0 THEN 0 ELSE x.MonthsElapsed END
             AS DECIMAL(18,3))                                                AS AccumulatedDepreciation,
        CAST(a.Cost - (a.Cost - a.SalvageValue) / x.TotalMonths
             * CASE WHEN x.MonthsElapsed > x.TotalMonths THEN x.TotalMonths
                    WHEN x.MonthsElapsed < 0 THEN 0 ELSE x.MonthsElapsed END
             AS DECIMAL(18,3))                                                AS BookValue
FROM dbo.Asset a
CROSS APPLY (
    SELECT  a.LifeYears * 12.0 AS TotalMonths,
            DATEDIFF(MONTH, a.InServiceDate, CAST(SYSDATETIME() AS DATE))
            - CASE WHEN DAY(CAST(SYSDATETIME() AS DATE)) < DAY(a.InServiceDate) THEN 1 ELSE 0 END AS MonthsElapsed
) x;
GO

-- End-of-life alerts screen: expired assets and assets in their last 12 months
CREATE VIEW dbo.vw_EndOfLifeAlerts AS
SELECT  v.AssetId, v.SerialNo, v.Name, v.CategoryId, v.Status, v.BookValue, v.RemainingMonths,
        CASE WHEN v.RemainingMonths = 0 THEN N'Expired' ELSE N'LastYear' END AS AlertType,
        c.PersonId, p.FullName AS HolderName
FROM dbo.vw_AssetValuation v
LEFT JOIN dbo.AssetCustody c ON c.AssetId = v.AssetId AND c.ReturnDate IS NULL
LEFT JOIN dbo.Person p       ON p.PersonId = c.PersonId
WHERE v.Status IN (N'Available', N'InCustody')
  AND v.RemainingMonths <= 12;
GO

/* ---------- 6. Stored procedures (each business operation = one transaction) ---------- */
CREATE PROCEDURE dbo.sp_HandoverAsset
    @AssetId INT, @PersonId INT, @Condition NVARCHAR(30), @Date DATE, @Notes NVARCHAR(300) = NULL, @UserId INT
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRAN;
        DECLARE @status NVARCHAR(20);
        SELECT @status = Status FROM dbo.Asset WITH (UPDLOCK, ROWLOCK) WHERE AssetId = @AssetId;
        IF @status IS NULL            THROW 50001, N'Asset not found.', 1;
        IF @status <> N'Available'    THROW 50002, N'Asset is not available for handover.', 1;
        IF NOT EXISTS (SELECT 1 FROM dbo.Person WHERE PersonId = @PersonId AND IsActive = 1)
                                      THROW 50003, N'Person not found or inactive.', 1;
        INSERT dbo.AssetCustody (AssetId, PersonId, HandoverDate, ConditionAtHandover, Notes, CreatedBy)
        VALUES (@AssetId, @PersonId, @Date, @Condition, @Notes, @UserId);
        UPDATE dbo.Asset SET Status = N'InCustody' WHERE AssetId = @AssetId;
        INSERT dbo.AuditLog (UserId, Action, EntityName, EntityId, Details)
        VALUES (@UserId, N'Handover', N'Asset', @AssetId, CONCAT(N'PersonId=', @PersonId));
    COMMIT;
END;
GO

CREATE PROCEDURE dbo.sp_ReceiveAsset
    @AssetId INT, @Condition NVARCHAR(30), @Date DATE, @UserId INT
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRAN;
        DECLARE @custodyId INT;
        SELECT @custodyId = CustodyId FROM dbo.AssetCustody WITH (UPDLOCK, ROWLOCK)
        WHERE AssetId = @AssetId AND ReturnDate IS NULL;
        IF @custodyId IS NULL THROW 50004, N'Asset has no open custody.', 1;
        UPDATE dbo.AssetCustody SET ReturnDate = @Date, ConditionAtReturn = @Condition WHERE CustodyId = @custodyId;
        UPDATE dbo.Asset SET Status = N'Available' WHERE AssetId = @AssetId;
        INSERT dbo.AuditLog (UserId, Action, EntityName, EntityId, Details)
        VALUES (@UserId, N'Receive', N'Asset', @AssetId, @Condition);
    COMMIT;
END;
GO

CREATE PROCEDURE dbo.sp_ProposeDisposal
    @AssetId INT, @Reason NVARCHAR(300), @UserId INT
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRAN;
        IF NOT EXISTS (SELECT 1 FROM dbo.Asset WHERE AssetId = @AssetId AND Status = N'Available')
            THROW 50005, N'Only an available (not in custody) asset can be proposed for disposal.', 1;
        INSERT dbo.Disposal (AssetId, Reason, ProposedBy) VALUES (@AssetId, @Reason, @UserId);
        INSERT dbo.AuditLog (UserId, Action, EntityName, EntityId, Details)
        VALUES (@UserId, N'ProposeDisposal', N'Asset', @AssetId, @Reason);
    COMMIT;
END;
GO

CREATE PROCEDURE dbo.sp_ApproveDisposal
    @DisposalId INT, @Approve BIT, @DocumentNo NVARCHAR(50) = NULL, @ManagerId INT
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRAN;
        IF NOT EXISTS (SELECT 1 FROM dbo.[User] WHERE UserId = @ManagerId AND Role = N'Manager' AND IsActive = 1)
            THROW 50006, N'Only a manager can approve disposal.', 1;
        DECLARE @assetId INT, @st NVARCHAR(20);
        SELECT @assetId = AssetId, @st = Status FROM dbo.Disposal WITH (UPDLOCK) WHERE DisposalId = @DisposalId;
        IF @assetId IS NULL OR @st <> N'Proposed' THROW 50007, N'Disposal request is not pending.', 1;
        IF @Approve = 1
        BEGIN
            IF NOT EXISTS (SELECT 1 FROM dbo.Asset WHERE AssetId = @assetId AND Status = N'Available')
                THROW 50008, N'Asset must be received (not in custody) before disposal.', 1;
            UPDATE dbo.Disposal SET Status = N'Approved', ApprovedBy = @ManagerId,
                   ApprovedDate = CAST(SYSDATETIME() AS DATE), DocumentNo = @DocumentNo WHERE DisposalId = @DisposalId;
            UPDATE dbo.Asset SET Status = N'Disposed' WHERE AssetId = @assetId;
        END
        ELSE
            UPDATE dbo.Disposal SET Status = N'Rejected', ApprovedBy = @ManagerId,
                   ApprovedDate = CAST(SYSDATETIME() AS DATE) WHERE DisposalId = @DisposalId;
        INSERT dbo.AuditLog (UserId, Action, EntityName, EntityId, Details)
        VALUES (@ManagerId, CASE WHEN @Approve = 1 THEN N'ApproveDisposal' ELSE N'RejectDisposal' END, N'Asset', @assetId, @DocumentNo);
    COMMIT;
END;
GO

/* ---------- 7. Seed data ---------- */
INSERT dbo.AssetCategory (Name, DefaultLifeYears) VALUES
 (N'أجهزة حاسوب', 5), (N'طابعات وملحقات', 4), (N'أثاث مكتبي', 10), (N'أجهزة كهربائية', 7), (N'معدات ومختبرات', 8);
-- The first Manager account is created from the application (first-run screen),
-- because the password hash and salt are generated in C#.
GO
