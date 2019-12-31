
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace EasyShop.Services.ExtensionMethods
{
    public static class GetRawTargetExtension
    {
        /// <summary>
        /// Gets the raw target of an HTTP request.
        /// /// </summary>
        /// /// <returns>Raw target of an HTTP request</returns>
        /// /// <remarks>
        /// /// ASP.NET Core manipulates the HTTP request parameters exposed to pipeline
        /// /// components via the HttpRequest class. This extension method delivers an untainted
        /// /// request target. https://tools.ietf.org/html/rfc7230#section-5.3
        /// /// </remarks>
        public static string GetRawTarget(this HttpRequest request)
        {
            var httpRequestFeature = request.HttpContext.Features.Get<IHttpRequestFeature>();
            return httpRequestFeature.RawTarget;
        }
    }
}
