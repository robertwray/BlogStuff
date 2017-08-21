IF EXISTS (SELECT 1 FROM sys.assemblies WHERE name = 'EarliestAndLatest')
BEGIN
	DROP ASSEMBLY [EarliestAndLatest]
END
GO

CREATE ASSEMBLY  [EarliestAndLatest]
FROM 'DRIVE:\Path\To\Assembly\EarliestAndLatestSQLServerCLRFunctions.dll'
WITH PERMISSION_SET = SAFE;
GO
