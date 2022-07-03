// <copyright file="DashboardManagementController.cs" company="APIMatic">
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
    /// DashboardManagementController.
    /// </summary>
    public class DashboardManagementController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardManagementController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        internal DashboardManagementController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers)
            : base(config, httpClient, authManagers)
        {
        }

        /// <summary>
        /// Import an API Version by specifying file path address of an API Spec to replace an existing version.
        /// </summary>
        /// <param name="file">Required parameter: API Spec file to be inmported.</param>
        /// <param name="apiEntityId">Required parameter: Unique API Entity Identifier.</param>
        public void InplaceAPIImportViaFile(
                FileStreamInfo file,
                string apiEntityId)
        {
            Task t = this.InplaceAPIImportViaFileAsync(file, apiEntityId);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Import an API Version by specifying file path address of an API Spec to replace an existing version.
        /// </summary>
        /// <param name="file">Required parameter: API Spec file to be inmported.</param>
        /// <param name="apiEntityId">Required parameter: Unique API Entity Identifier.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task InplaceAPIImportViaFileAsync(
                FileStreamInfo file,
                string apiEntityId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/api-entities/{apiEntityId}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "apiEntityId", apiEntityId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Accept", "application/vnd.apimatic.apiEntity.full.v1+json" },
            };

            var fileHeaders = new Dictionary<string, IReadOnlyCollection<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "content-type", new[]
                    {
                        string.IsNullOrEmpty(file.ContentType) ? "application/octect-stream" : file.ContentType,
                    }
                },
            };

            // append form/field parameters.
            var fields = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("file", CreateFileMultipartContent(file, fileHeaders)),
            };

            // remove null parameters.
            fields = fields.Where(kvp => kvp.Value != null).ToList();

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Put(queryBuilder.ToString(), headers, fields);

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }
    }
}