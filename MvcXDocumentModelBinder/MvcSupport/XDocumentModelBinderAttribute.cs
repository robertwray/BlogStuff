using System.Web.Mvc;

namespace MvcXDocumentModelBinder.MvcSupport
{
    public class XDocumentModelBinderAttribute : CustomModelBinderAttribute
    {
        /// <summary>
        /// Get a model binder that transforms an XML string into an XDocument
        /// </summary>
        public override IModelBinder GetBinder()
        {
            return XDocumentModelBinder.Instance;
        }
    }
}