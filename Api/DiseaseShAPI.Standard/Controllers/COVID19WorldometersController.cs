// <copyright file="COVID19WorldometersController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace DiseaseShAPI.Standard.Controllers
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
    using DiseaseShAPI.Standard;
    using DiseaseShAPI.Standard.Authentication;
    using DiseaseShAPI.Standard.Http.Client;
    using DiseaseShAPI.Standard.Http.Request;
    using DiseaseShAPI.Standard.Http.Request.Configuration;
    using DiseaseShAPI.Standard.Http.Response;
    using DiseaseShAPI.Standard.Utilities;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// COVID19WorldometersController.
    /// </summary>
    public class COVID19WorldometersController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="COVID19WorldometersController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal COVID19WorldometersController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Get global COVID-19 totals for today, yesterday and two days ago.
        /// </summary>
        /// <param name="yesterday">Optional parameter: Queries data reported a day ago.</param>
        /// <param name="twoDaysAgo">Optional parameter: Queries data reported two days ago.</param>
        /// <param name="allowNull">Optional parameter: By default, if a value is missing, it is returned as 0. This allows nulls to be returned.</param>
        /// <returns>Returns the Models.CovidAll response from the API call.</returns>
        public Models.CovidAll GlobalCOVID19Totals(
                string yesterday = "false",
                string twoDaysAgo = "false",
                string allowNull = null)
        {
            Task<Models.CovidAll> t = this.GlobalCOVID19TotalsAsync(yesterday, twoDaysAgo, allowNull);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Get global COVID-19 totals for today, yesterday and two days ago.
        /// </summary>
        /// <param name="yesterday">Optional parameter: Queries data reported a day ago.</param>
        /// <param name="twoDaysAgo">Optional parameter: Queries data reported two days ago.</param>
        /// <param name="allowNull">Optional parameter: By default, if a value is missing, it is returned as 0. This allows nulls to be returned.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CovidAll response from the API call.</returns>
        public async Task<Models.CovidAll> GlobalCOVID19TotalsAsync(
                string yesterday = "false",
                string twoDaysAgo = "false",
                string allowNull = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v3/covid-19/all");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "yesterday", (yesterday != null) ? yesterday : "false" },
                { "twoDaysAgo", (twoDaysAgo != null) ? twoDaysAgo : "false" },
                { "allowNull", allowNull },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.CovidAll>(response.Body);
        }

        /// <summary>
        /// Get COVID-19 totals for a specific country.
        /// </summary>
        /// <param name="country">Required parameter: A country name, iso2, iso3, or country ID code.</param>
        /// <param name="yesterday">Optional parameter: Queries data reported a day ago.</param>
        /// <param name="twoDaysAgo">Optional parameter: Queries data reported two days ago.</param>
        /// <param name="strict">Optional parameter: Setting to false gives you the ability to fuzzy search countries (i.e. Oman vs. rOMANia).</param>
        /// <param name="allowNull">Optional parameter: By default, if a value is missing, it is returned as 0. This allows nulls to be returned.</param>
        /// <returns>Returns the Models.CovidCountry response from the API call.</returns>
        public Models.CovidCountry COVID19TotalsForACountry(
                string country,
                string yesterday = "false",
                string twoDaysAgo = "false",
                string strict = null,
                string allowNull = null)
        {
            Task<Models.CovidCountry> t = this.COVID19TotalsForACountryAsync(country, yesterday, twoDaysAgo, strict, allowNull);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Get COVID-19 totals for a specific country.
        /// </summary>
        /// <param name="country">Required parameter: A country name, iso2, iso3, or country ID code.</param>
        /// <param name="yesterday">Optional parameter: Queries data reported a day ago.</param>
        /// <param name="twoDaysAgo">Optional parameter: Queries data reported two days ago.</param>
        /// <param name="strict">Optional parameter: Setting to false gives you the ability to fuzzy search countries (i.e. Oman vs. rOMANia).</param>
        /// <param name="allowNull">Optional parameter: By default, if a value is missing, it is returned as 0. This allows nulls to be returned.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CovidCountry response from the API call.</returns>
        public async Task<Models.CovidCountry> COVID19TotalsForACountryAsync(
                string country,
                string yesterday = "false",
                string twoDaysAgo = "false",
                string strict = null,
                string allowNull = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v3/covid-19/countries/{country}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "country", country },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "yesterday", (yesterday != null) ? yesterday : "false" },
                { "twoDaysAgo", (twoDaysAgo != null) ? twoDaysAgo : "false" },
                { "strict", strict },
                { "allowNull", allowNull },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.CovidCountry>(response.Body);
        }

        /// <summary>
        /// Get COVID-19 totals for a specific set of countries.
        /// </summary>
        /// <param name="countries">Required parameter: Multiple country names, iso2, iso3, or country IDs separated by commas.</param>
        /// <param name="yesterday">Optional parameter: Queries data reported a day ago.</param>
        /// <param name="twoDaysAgo">Optional parameter: Queries data reported two days ago.</param>
        /// <param name="allowNull">Optional parameter: By default, if a value is missing, it is returned as 0. This allows nulls to be returned.</param>
        /// <returns>Returns the List of Models.CovidCountry response from the API call.</returns>
        public List<Models.CovidCountry> COVID19TotalsForASetOfCountries(
                string countries,
                string yesterday = "false",
                string twoDaysAgo = "false",
                string allowNull = null)
        {
            Task<List<Models.CovidCountry>> t = this.COVID19TotalsForASetOfCountriesAsync(countries, yesterday, twoDaysAgo, allowNull);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Get COVID-19 totals for a specific set of countries.
        /// </summary>
        /// <param name="countries">Required parameter: Multiple country names, iso2, iso3, or country IDs separated by commas.</param>
        /// <param name="yesterday">Optional parameter: Queries data reported a day ago.</param>
        /// <param name="twoDaysAgo">Optional parameter: Queries data reported two days ago.</param>
        /// <param name="allowNull">Optional parameter: By default, if a value is missing, it is returned as 0. This allows nulls to be returned.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.CovidCountry response from the API call.</returns>
        public async Task<List<Models.CovidCountry>> COVID19TotalsForASetOfCountriesAsync(
                string countries,
                string yesterday = "false",
                string twoDaysAgo = "false",
                string allowNull = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v3/covid-19/countries/{countries}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "countries", countries },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "yesterday", (yesterday != null) ? yesterday : "false" },
                { "twoDaysAgo", (twoDaysAgo != null) ? twoDaysAgo : "false" },
                { "allowNull", allowNull },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<List<Models.CovidCountry>>(response.Body);
        }
    }
}