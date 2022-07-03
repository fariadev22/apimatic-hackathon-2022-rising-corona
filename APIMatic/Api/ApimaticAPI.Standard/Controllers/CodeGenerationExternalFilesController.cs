// <copyright file="CodeGenerationExternalFilesController.cs" company="APIMatic">
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
    /// CodeGenerationExternalFilesController.
    /// </summary>
    public class CodeGenerationExternalFilesController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CodeGenerationExternalFilesController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        internal CodeGenerationExternalFilesController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers)
            : base(config, httpClient, authManagers)
        {
        }

        /// <summary>
        /// Download a generated SDK by specifying CodeGen Id as input.
        /// </summary>
        /// <param name="codeGenId">Required parameter: Id associated with each generation.</param>
        /// <returns>Returns the Stream response from the API call.</returns>
        public Stream DownloadSDK(
                string codeGenId)
        {
            Task<Stream> t = this.DownloadSDKAsync(codeGenId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Download a generated SDK by specifying CodeGen Id as input.
        /// </summary>
        /// <param name="codeGenId">Required parameter: Id associated with each generation.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Stream response from the API call.</returns>
        public async Task<Stream> DownloadSDKAsync(
                string codeGenId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/code-generations/{codeGenId}/generated-sdk");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
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