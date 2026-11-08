/* =====================================================================
   تنظيف: يحذف جداول النظام التي أُنشئت بالخطأ في قاعدة master
   (يحدث عندما يفشل إنشاء AssetsDB في التشغيل الأول).
   شغّله مرة واحدة فقط إذا ظهرت أخطاء "There is already an object named ...".
   ===================================================================== */
USE master;
GO
DROP PROCEDURE IF EXISTS dbo.sp_ApproveDisposal, dbo.sp_ProposeDisposal, dbo.sp_ReceiveAsset, dbo.sp_HandoverAsset;
DROP VIEW IF EXISTS dbo.vw_EndOfLifeAlerts, dbo.vw_AssetValuation;
DROP TABLE IF EXISTS dbo.AuditLog, dbo.InventoryLine, dbo.InventorySession, dbo.Disposal, dbo.MaintenanceRecord,
                     dbo.AssetCustody, dbo.Asset, dbo.AssetCategory, dbo.[User], dbo.Person, dbo.Location, dbo.Department;
GO
PRINT N'تم التنظيف. شغّل الآن 01_AssetsDB.sql';
