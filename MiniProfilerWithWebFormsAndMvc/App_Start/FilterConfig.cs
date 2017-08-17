using StackExchange.Profiling.Mvc;
using System.Web.Mvc;

namespace MiniProfilerWithWebFormsAndMvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ProfilingActionFilter());
        }
    }
}