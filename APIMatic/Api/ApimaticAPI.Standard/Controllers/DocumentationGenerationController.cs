// <copyright file="DocumentationGenerationController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ApimaticAPI.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using ApimaticAPI.Standard;
    using ApimaticAPI.Standard.Authentication;
    using ApimaticAPI.Standard.Http.Client;
    using ApimaticAPI.Standard.Http.Request;
    using ApimaticAPI.Standard.Http.Request.Configuration;
    using ApimaticAPI.Standard.Http.Response;
    using ApimaticAPI.Standard.Utilities;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// DocumentationGenerationController.
    /// </summary>
    public class DocumentationGenerationController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentationGenerationController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        internal DocumentationGenerationController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers)
            : base(config, httpClient, authManagers)
        {
        }

        /// <summary>
        /// Generate and publish SDKs, Documentations and API Spec exports for your Portal.
        /// </summary>
        /// <param name="apiKey">Required parameter: Unique encrypted API Identifier.</param>
        public void PublishPortalArtifacts(
                string apiKey)
        {
            Task t = this.PublishPortalArtifactsAsync(apiKey);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Generate and publish SDKs, Documentations and API Spec exports for your Portal.
        /// </summary>
        /// <param name="apiKey">Required parameter: Unique encrypted API Identifier.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task PublishPortalArtifactsAsync(
                string apiKey,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/api-entities/{apiKey}/published-artifacts");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "apiKey", apiKey },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Post(queryBuilder.ToString(), headers, null);

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }
    }
}