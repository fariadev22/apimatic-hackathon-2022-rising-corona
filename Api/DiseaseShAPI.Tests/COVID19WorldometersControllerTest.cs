// <copyright file="COVID19WorldometersControllerTest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace DiseaseShAPI.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;
    using DiseaseShAPI.Standard;
    using DiseaseShAPI.Standard.Controllers;
    using DiseaseShAPI.Standard.Exceptions;
    using DiseaseShAPI.Standard.Http.Client;
    using DiseaseShAPI.Standard.Http.Response;
    using DiseaseShAPI.Standard.Utilities;
    using DiseaseShAPI.Tests.Helpers;
    using Newtonsoft.Json.Converters;
    using NUnit.Framework;

    /// <summary>
    /// COVID19WorldometersControllerTest.
    /// </summary>
    [TestFixture]
    public class COVID19WorldometersControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private COVID19WorldometersController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.COVID19WorldometersController;
        }

        /// <summary>
        /// Get global COVID-19 totals for today, yesterday and two days ago.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetGlobalCOVID19TotalsForTodayYesterdayAndTwoDaysAgo()
        {
            // Parameters for the API call
            string yesterday = null;
            string twoDaysAgo = null;
            string allowNull = null;

            // Perform API call
            Standard.Models.CovidAll result = null;
            try
            {
                result = await this.controller.GlobalCOVID19TotalsAsync(yesterday, twoDaysAgo, allowNull);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsJsonObjectProperSubsetOf(
                    "{\"updated\":1656840242476,\"cases\":554128007,\"todayCases\":136969,\"deaths\":6361007,\"todayDeaths\":248,\"recovered\":528892222,\"todayRecovered\":233011,\"active\":18874778,\"critical\":37000,\"casesPerOneMillion\":71089,\"deathsPerOneMillion\":816.1,\"tests\":6476303759,\"testsPerOneMillion\":816073.84,\"population\":7935928660,\"oneCasePerPeople\":0,\"oneDeathPerPeople\":0,\"oneTestPerPeople\":0,\"activePerOneMillion\":2378.4,\"recoveredPerOneMillion\":66645.28,\"criticalPerOneMillion\":4.66,\"affectedCountries\":230}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Get COVID-19 totals for a specific country.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCOVID19TotalsForACountry()
        {
            // Parameters for the API call
            string country = "Pakistan";
            string yesterday = null;
            string twoDaysAgo = null;
            string strict = null;
            string allowNull = null;

            // Perform API call
            Standard.Models.CovidCountry result = null;
            try
            {
                result = await this.controller.COVID19TotalsForACountryAsync(country, yesterday, twoDaysAgo, strict, allowNull);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsJsonObjectProperSubsetOf(
                    "{\"updated\":1656833417473,\"country\":\"Pakistan\",\"countryInfo\":{\"_id\":586,\"iso2\":\"PK\",\"iso3\":\"PAK\",\"lat\":30,\"long\":70,\"flag\":\"https://disease.sh/assets/img/flags/pk.png\"},\"cases\":1537947,\"todayCases\":650,\"deaths\":30401,\"todayDeaths\":2,\"recovered\":1499641,\"todayRecovered\":0,\"active\":7905,\"critical\":138,\"casesPerOneMillion\":6703,\"deathsPerOneMillion\":132,\"tests\":29045736,\"testsPerOneMillion\":126586,\"population\":229453967,\"continent\":\"Asia\",\"oneCasePerPeople\":149,\"oneDeathPerPeople\":7548,\"oneTestPerPeople\":8,\"activePerOneMillion\":34.45,\"recoveredPerOneMillion\":6535.69,\"criticalPerOneMillion\":0.6}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Get COVID-19 totals for a specific set of countries.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCOVID19TotalsForASetOfCountries()
        {
            // Parameters for the API call
            string countries = "Pakistan, China";
            string yesterday = null;
            string twoDaysAgo = null;
            string allowNull = null;

            // Perform API call
            List<Standard.Models.CovidCountry> result = null;
            try
            {
                result = await this.controller.COVID19TotalsForASetOfCountriesAsync(countries, yesterday, twoDaysAgo, allowNull);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsArrayOfJsonObjectsProperSubsetOf(
                    "[{\"updated\":1656833417473,\"country\":\"Pakistan\",\"countryInfo\":{\"_id\":586,\"iso2\":\"PK\",\"iso3\":\"PAK\",\"lat\":30,\"long\":70,\"flag\":\"https://disease.sh/assets/img/flags/pk.png\"},\"cases\":1537947,\"todayCases\":650,\"deaths\":30401,\"todayDeaths\":2,\"recovered\":1499641,\"todayRecovered\":0,\"active\":7905,\"critical\":138,\"casesPerOneMillion\":6703,\"deathsPerOneMillion\":132,\"tests\":29045736,\"testsPerOneMillion\":126586,\"population\":229453967,\"continent\":\"Asia\",\"oneCasePerPeople\":149,\"oneDeathPerPeople\":7548,\"oneTestPerPeople\":8,\"activePerOneMillion\":34.45,\"recoveredPerOneMillion\":6535.69,\"criticalPerOneMillion\":0.6},{\"updated\":1656833418183,\"country\":\"China\",\"countryInfo\":{\"_id\":156,\"iso2\":\"CN\",\"iso3\":\"CHN\",\"lat\":35,\"long\":105,\"flag\":\"https://disease.sh/assets/img/flags/cn.png\"},\"cases\":225851,\"todayCases\":104,\"deaths\":5226,\"todayDeaths\":0,\"recovered\":220115,\"todayRecovered\":40,\"active\":510,\"critical\":0,\"casesPerOneMillion\":157,\"deathsPerOneMillion\":4,\"tests\":160000000,\"testsPerOneMillion\":111163,\"population\":1439323776,\"continent\":\"Asia\",\"oneCasePerPeople\":6373,\"oneDeathPerPeople\":275416,\"oneTestPerPeople\":9,\"activePerOneMillion\":0.35,\"recoveredPerOneMillion\":152.93,\"criticalPerOneMillion\":0}]",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}