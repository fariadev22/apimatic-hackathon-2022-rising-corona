// <copyright file="ApimaticAPIClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ApimaticAPI.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using ApimaticAPI.Standard.Authentication;
    using ApimaticAPI.Standard.Controllers;
    using ApimaticAPI.Standard.Http.Client;
    using ApimaticAPI.Standard.Utilities;

    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class ApimaticAPIClient : IConfiguration
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Server, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Server, string>>
        {
            {
                Environment.Production, new Dictionary<Server, string>
                {
                    { Server.Default, "https://www.apimatic.io/api" },
                }
            },
        };

        private readonly IDictionary<string, IAuthManager> authManagers;
        private readonly IHttpClient httpClient;
        private readonly BasicAuthManager basicAuthManager;

        private readonly Lazy<DashboardManagementController> dashboardManagement;
        private readonly Lazy<CodeGenerationImportedApisController> codeGenerationImportedApis;
        private readonly Lazy<DocumentationGenerationController> documentationGeneration;

        private ApimaticAPIClient(
            Environment environment,
            string email,
            string password,
            IDictionary<string, IAuthManager> authManagers,
            IHttpClient httpClient,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.Environment = environment;
            this.httpClient = httpClient;
            this.authManagers = (authManagers == null) ? new Dictionary<string, IAuthManager>() : new Dictionary<string, IAuthManager>(authManagers);
            this.HttpClientConfiguration = httpClientConfiguration;

            this.dashboardManagement = new Lazy<DashboardManagementController>(
                () => new DashboardManagementController(this, this.httpClient, this.authManagers));
            this.codeGenerationImportedApis = new Lazy<CodeGenerationImportedApisController>(
                () => new CodeGenerationImportedApisController(this, this.httpClient, this.authManagers));
            this.documentationGeneration = new Lazy<DocumentationGenerationController>(
                () => new DocumentationGenerationController(this, this.httpClient, this.authManagers));

            if (this.authManagers.ContainsKey("global"))
            {
                this.basicAuthManager = (BasicAuthManager)this.authManagers["global"];
            }

            if (!this.authManagers.ContainsKey("global")
                || !this.BasicAuthCredentials.Equals(email, password))
            {
                this.basicAuthManager = new BasicAuthManager(email, password);
                this.authManagers["global"] = this.basicAuthManager;
            }
        }

        /// <summary>
        /// Gets DashboardManagementController controller.
        /// </summary>
        public DashboardManagementController DashboardManagementController => this.dashboardManagement.Value;

        /// <summary>
        /// Gets CodeGenerationImportedApisController controller.
        /// </summary>
        public CodeGenerationImportedApisController CodeGenerationImportedApisController => this.codeGenerationImportedApis.Value;

        /// <summary>
        /// Gets DocumentationGenerationController controller.
        /// </summary>
        public DocumentationGenerationController DocumentationGenerationController => this.documentationGeneration.Value;

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets Environment.
        /// Current API environment.
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// Gets auth managers.
        /// </summary>
        internal IDictionary<string, IAuthManager> AuthManagers => this.authManagers;

        /// <summary>
        /// Gets http client.
        /// </summary>
        internal IHttpClient HttpClient => this.httpClient;

        /// <summary>
        /// Gets the credentials to use with BasicAuth.
        /// </summary>
        public IBasicAuthCredentials BasicAuthCredentials => this.basicAuthManager;

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Default)
        {
            StringBuilder url = new StringBuilder(EnvironmentsMap[this.Environment][alias]);
            ApiHelper.AppendUrlWithTemplateParameters(url, this.GetBaseUriParameters());

            return url.ToString();
        }

        /// <summary>
        /// Creates an object of the ApimaticAPIClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Environment(this.Environment)
                .BasicAuthCredentials(this.basicAuthManager.Email, this.basicAuthManager.Password)
                .HttpClient(this.httpClient)
                .AuthManagers(this.authManagers)
                .HttpClientConfig(config => config.Build());

            return builder;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return
                $"Environment = {this.Environment}, " +
                $"HttpClientConfiguration = {this.HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> ApimaticAPIClient.</returns>
        internal static ApimaticAPIClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string environment = System.Environment.GetEnvironmentVariable("APIMATIC_API_STANDARD_ENVIRONMENT");
            string email = System.Environment.GetEnvironmentVariable("APIMATIC_API_STANDARD_EMAIL");
            string password = System.Environment.GetEnvironmentVariable("APIMATIC_API_STANDARD_PASSWORD");

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            if (email != null && password != null)
            {
                builder.BasicAuthCredentials(email, password);
            }

            return builder.Build();
        }

        /// <summary>
        /// Makes a list of the BaseURL parameters.
        /// </summary>
        /// <returns>Returns the parameters list.</returns>
        private List<KeyValuePair<string, object>> GetBaseUriParameters()
        {
            List<KeyValuePair<string, object>> kvpList = new List<KeyValuePair<string, object>>()
            {
            };
            return kvpList;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Environment environment = ApimaticAPI.Standard.Environment.Production;
            private string email = "yourusername@apimatic.io";
            private string password = "yourapimaticpassword";
            private IDictionary<string, IAuthManager> authManagers = new Dictionary<string, IAuthManager>();
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();
            private IHttpClient httpClient;

            /// <summary>
            /// Sets credentials for BasicAuth.
            /// </summary>
            /// <param name="email">Email.</param>
            /// <param name="password">Password.</param>
            /// <returns>Builder.</returns>
            public Builder BasicAuthCredentials(string email, string password)
            {
                this.email = email ?? throw new ArgumentNullException(nameof(email));
                this.password = password ?? throw new ArgumentNullException(nameof(password));
                return this;
            }

            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets HttpClientConfig.
            /// </summary>
            /// <param name="action"> Action. </param>
            /// <returns>Builder.</returns>
            public Builder HttpClientConfig(Action<HttpClientConfiguration.Builder> action)
            {
                if (action is null)
                {
                    throw new ArgumentNullException(nameof(action));
                }

                action(this.httpClientConfig);
                return this;
            }

            /// <summary>
            /// Sets the IHttpClient for the Builder.
            /// </summary>
            /// <param name="httpClient"> http client. </param>
            /// <returns>Builder.</returns>
            internal Builder HttpClient(IHttpClient httpClient)
            {
                this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
                return this;
            }

            /// <summary>
            /// Sets the authentication managers for the Builder.
            /// </summary>
            /// <param name="authManagers"> auth managers. </param>
            /// <returns>Builder.</returns>
            internal Builder AuthManagers(IDictionary<string, IAuthManager> authManagers)
            {
                this.authManagers = authManagers ?? throw new ArgumentNullException(nameof(authManagers));
                return this;
            }

            /// <summary>
            /// Creates an object of the ApimaticAPIClient using the values provided for the builder.
            /// </summary>
            /// <returns>ApimaticAPIClient.</returns>
            public ApimaticAPIClient Build()
            {
                this.httpClient = new HttpClientWrapper(this.httpClientConfig.Build());

                return new ApimaticAPIClient(
                    this.environment,
                    this.email,
                    this.password,
                    this.authManagers,
                    this.httpClient,
                    this.httpClientConfig.Build());
            }
        }
    }
}
