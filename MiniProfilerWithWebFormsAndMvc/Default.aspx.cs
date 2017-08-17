using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniProfilerWithWebFormsAndMvc
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var profile = MiniProfiler.Current.Step("Page_Load"))
            {
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}