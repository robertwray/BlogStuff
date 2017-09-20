using MiniProfilerWithWebFormsAndMvc.Models.MarkupViaMVC;
using System;
using System.Web.Mvc;

namespace MiniProfilerWithWebFormsAndMvc.Controllers
{
    public class MarkupViaMVCController : Controller
    {
        // GET: MarkupViaMVC
        public ActionResult Index()
        {
            var model = new IndexModel
            {
                Number = 1,
                Text = "Some Text",
                DateAndTime = DateTime.Now
            };

            return View(model);
        }
    }
}