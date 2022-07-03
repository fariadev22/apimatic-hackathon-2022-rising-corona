// <copyright file="CodeGenerationImportedApisController.cs" company="APIMatic">
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
    /// CodeGenerationImportedApisController.
    /// </summary>
    public class CodeGenerationImportedApisController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CodeGenerationImportedApisController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        internal CodeGenerationImportedApisController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers)
            : base(config, httpClient, authManagers)
        {
        }

        /// <summary>
        /// Generate SDK against a specific API using the API Entity Identifier and specifying the platform template.
        /// </summary>
        /// <param name="apiEntityId">Required parameter: Unique API version identifier.</param>
        /// <param name="template">Required parameter: Platform Template.</param>
        /// <returns>Returns the Models.APIEntityCodeGeneration response from the API call.</returns>
        public Models.APIEntityCodeGeneration GenerateSDK(
                string apiEntityId,
                Models.Platforms template)
        {
            Task<Models.APIEntityCodeGeneration> t = this.GenerateSDKAsync(apiEntityId, template);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Generate SDK against a specific API using the API Entity Identifier and specifying the platform template.
        /// </summary>
        /// <param name="apiEntityId">Required parameter: Unique API version identifier.</param>
        /// <param name="template">Required parameter: Platform Template.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.APIEntityCodeGeneration response from the API call.</returns>
        public async Task<Models.APIEntityCodeGeneration> GenerateSDKAsync(
                string apiEntityId,
                Models.Platforms template,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/api-entities/{apiEntityId}/code-generations");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "apiEntityId", apiEntityId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // append form/field parameters.
            var fields = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("Template", ApiHelper.JsonSerialize(template).Trim('\"')),
            };

            // remove null parameters.
            fields = fields.Where(kvp => kvp.Value != null).ToList();

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Post(queryBuilder.ToString(), headers, fields);

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.APIEntityCodeGeneration>(response.Body);
        }

        /// <summary>
        /// Download SDK generated against a specific API using API Entity Id and the CodeGen Id.
        /// </summary>
        /// <param name="apiEntityId">Required parameter: Unique API Entity  identifier.</param>
        /// <param name="codeGenId">Required parameter: Unique Code Generation identifier.</param>
        /// <returns>Returns the Stream response from the API call.</returns>
        public Stream DownloadSDK(
                string apiEntityId,
                string codeGenId)
        {
            Task<Stream> t = this.DownloadSDKAsync(apiEntityId, codeGenId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Download SDK generated against a specific API using API Entity Id and the CodeGen Id.
        /// </summary>
        /// <param name="apiEntityId">Required parameter: Unique API Entity  identifier.</param>
        /// <param name="codeGenId">Required parameter: Unique Code Generation identifier.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Stream response from the API call.</returns>
        public async Task<Stream> DownloadSDKAsync(
                string apiEntityId,
                string codeGenId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/api-entities/{apiEntityId}/code-generations/{codeGenId}/generated-sdk");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "apiEntityId", apiEntityId },
                { "codeGenId", codeGenId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpResponse response = await this.GetClientInstance().ExecuteAsBinaryAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return response.RawBody;
        }
    }
}