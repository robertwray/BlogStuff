using System.Web.Mvc;
using System.Xml.Linq;

namespace MvcXDocumentModelBinder.MvcSupport
{
    /// <summary>
    /// A model binder that transforms the input into an XmlDocument
    /// </summary>
    public class XDocumentModelBinder : IModelBinder
    {
        internal static XDocumentModelBinder Instance { get; } = new XDocumentModelBinder();
        object IModelBinder.BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // First check if request validation is required
            var shouldPerformRequestValidation = controllerContext.Controller.ValidateRequest && bindingContext.ModelMetadata.RequestValidationEnabled;

            var incomingData = bindingContext.GetValueFromValueProvider(shouldPerformRequestValidation).AttemptedValue;

            var document = XDocument.Parse(incomingData);

            return document;
        }
    }

    /// <summary>
    /// Helper methods for XDocumentModelBinder
    /// </summary>
    public static class ModelBindingContextExtensions
    {
        /// <remarks>
        /// Code originally from http://blogs.taiga.nl/martijn/2011/09/29/custom-model-binders-and-request-validation/
        /// </remarks>
        public static ValueProviderResult GetValueFromValueProvider(this ModelBindingContext bindingContext, bool performRequestValidation)
        {
            var unvalidatedValueProvider = bindingContext.ValueProvider as IUnvalidatedValueProvider;
            return (unvalidatedValueProvider != null)
                        ? unvalidatedValueProvider.GetValue(bindingContext.ModelName, !performRequestValidation)
                        : bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        }
    }
}