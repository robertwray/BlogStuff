using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Runtime.InteropServices;

namespace EarliestAndLatestSQLServerCLRFunctions
{
    [StructLayout(LayoutKind.Sequential)]
    [SqlUserDefinedAggregate(Format.Native, IsInvariantToDuplicates = true, IsInvariantToNulls = true, IsInvariantToOrder = true, IsNullIfEmpty = true, Name = "Earliest")]
    public partial class Earliest
    {
        private SqlDateTime earliestDateTime;
        private SqlInt32 earliestValue;

        public void Init()
        {
            earliestDateTime = SqlDateTime.Null;
            earliestValue = SqlInt32.Null;
        }

        public void Accumulate(SqlDateTime recordDateTime, SqlInt32 value)
        {
            if (earliestDateTime.IsNull)
            {
                earliestDateTime = recordDateTime;
                earliestValue = value;
            }
            else
            {
                if (recordDateTime < earliestDateTime)
                {
                    earliestDateTime = recordDateTime;
                    earliestValue = value;
                }
            }
        }

        public void Merge(Earliest value)
        {
            if ((value.earliestDateTime < earliestDateTime) || (earliestDateTime.IsNull))
            {
                earliestValue = value.earliestValue;
                earliestDateTime = value.earliestDateTime;
            }
        }

        public SqlInt32 Terminate()
        {
            return earliestValue;
        }
    };
}
