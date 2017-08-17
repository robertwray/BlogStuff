using System.Web.Mvc;
using StackExchange.Profiling;

namespace MiniProfilerWithWebFormsAndMvc.Controllers
{
    public class JavascriptController : Controller
    {
        public MiniProfiler Profiler
        {
            get
            {
                return MiniProfiler.Current;
            }
        }

        public ActionResult GetDataProfiledServerSide(int howLongShouldIWait = 200)
        {
            using (Profiler.Step(nameof(GetDataProfiledServerSide)))
            {
                var data = new { Item1 = "Hello", Item2 = "World!", Item3 = 123 };

                using (Profiler.Step("Long Running Operation"))
                {
                    // Simulate a "slow" request
                    System.Threading.Thread.Sleep(howLongShouldIWait <= 0 ? 200 : howLongShouldIWait);
                }

                AnotherMethodThatDoesStuff();

                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetDataWithoutServerSideProfiling(int howLongShouldIWait = 200)
        {
            var data = new { Item1 = "Hello", Item2 = "World!", Item3 = 123 };

            // Simulate a "slow" request
            System.Threading.Thread.Sleep(howLongShouldIWait <= 0 ? 200 : howLongShouldIWait);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        private void AnotherMethodThatDoesStuff()
        {
            using (Profiler.Step(nameof(AnotherMethodThatDoesStuff)))
            {
                System.Threading.Thread.Sleep(50);
            }
        }
    }
}