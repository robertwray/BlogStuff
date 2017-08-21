using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Runtime.InteropServices;

namespace EarliestAndLatestSQLServerCLRFunctions
{
    [StructLayout(LayoutKind.Sequential)]
    [SqlUserDefinedAggregate(Format.Native, IsInvariantToDuplicates = true, IsInvariantToNulls = true, IsInvariantToOrder = true, IsNullIfEmpty = true, Name = "Latest")]
    public partial class Latest
    {
        private SqlDateTime latestDateTime;
        private SqlInt32 latestValue;

        public void Init()
        {
            latestDateTime = SqlDateTime.Null;
            latestValue = SqlInt32.Null;
        }

        public void Accumulate(SqlDateTime recordDateTime, SqlInt32 value)
        {
            if (latestDateTime.IsNull)
            {
                latestDateTime = recordDateTime;
                latestValue = value;
            }
            else
            {
                if (recordDateTime > latestDateTime)
                {
                    latestDateTime = recordDateTime;
                    latestValue = value;
                }
            }
        }

        public void Merge(Latest value)
        {
            if ((value.latestDateTime > latestDateTime) || (latestDateTime.IsNull))
            {
                latestValue = value.latestValue;
                latestDateTime = value.latestDateTime;
            }
        }

        public SqlInt32 Terminate()
        {
            return latestValue;
        }
    };
}
