using MvcXDocumentModelBinder.MvcSupport;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MvcXDocumentModelBinder.Controllers
{
    public class XmlController : Controller
    {
        // GET: Xml
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult TransferXMLData([XDocumentModelBinder] XDocument xmlText, int? otherValue)
        {
            var response = new
            {
                Success = true
            };

            return Json(response);
        }
    }
}