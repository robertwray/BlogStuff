CREATE AGGREGATE  [dbo].[Earliest]
(@recordDateTime [datetime], @value [int])
RETURNS[int]
EXTERNAL NAME [EarliestAndLatest].[EarliestAndLatestSQLServerCLRFunctions.Earliest]
GO


CREATE AGGREGATE [dbo].[Latest]
(@recordDateTime [datetime], @value [int])
RETURNS[int]
EXTERNAL NAME [EarliestAndLatest].[EarliestAndLatestSQLServerCLRFunctions.Latest]
GO