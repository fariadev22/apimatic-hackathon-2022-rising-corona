// <copyright file="CovidAll.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace DiseaseShAPI.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DiseaseShAPI.Standard;
    using DiseaseShAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// CovidAll.
    /// </summary>
    public class CovidAll
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CovidAll"/> class.
        /// </summary>
        public CovidAll()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CovidAll"/> class.
        /// </summary>
        /// <param name="updated">updated.</param>
        /// <param name="cases">cases.</param>
        /// <param name="todayCases">todayCases.</param>
        /// <param name="deaths">deaths.</param>
        /// <param name="recovered">recovered.</param>
        /// <param name="todayRecovered">todayRecovered.</param>
        /// <param name="active">active.</param>
        /// <param name="critical">critical.</param>
        /// <param name="casesPerOneMillion">casesPerOneMillion.</param>
        /// <param name="deathsPerOneMillion">deathsPerOneMillion.</param>
        /// <param name="tests">tests.</param>
        /// <param name="testsPerOneMillion">testsPerOneMillion.</param>
        /// <param name="population">population.</param>
        /// <param name="oneCasePerPeople">oneCasePerPeople.</param>
        /// <param name="oneDeathPerPeople">oneDeathPerPeople.</param>
        /// <param name="oneTestPerPeople">oneTestPerPeople.</param>
        /// <param name="activePerOneMillion">activePerOneMillion.</param>
        /// <param name="recoveredPerOneMillion">recoveredPerOneMillion.</param>
        /// <param name="criticalPerOneMillion">criticalPerOneMillion.</param>
        /// <param name="affectedCountries">affectedCountries.</param>
        public CovidAll(
            double? updated = null,
            double? cases = null,
            double? todayCases = null,
            double? deaths = null,
            double? recovered = null,
            double? todayRecovered = null,
            double? active = null,
            double? critical = null,
            double? casesPerOneMillion = null,
            double? deathsPerOneMillion = null,
            double? tests = null,
            double? testsPerOneMillion = null,
            double? population = null,
            double? oneCasePerPeople = null,
            double? oneDeathPerPeople = null,
            double? oneTestPerPeople = null,
            double? activePerOneMillion = null,
            double? recoveredPerOneMillion = null,
            double? criticalPerOneMillion = null,
            double? affectedCountries = null)
        {
            this.Updated = updated;
            this.Cases = cases;
            this.TodayCases = todayCases;
            this.Deaths = deaths;
            this.Recovered = recovered;
            this.TodayRecovered = todayRecovered;
            this.Active = active;
            this.Critical = critical;
            this.CasesPerOneMillion = casesPerOneMillion;
            this.DeathsPerOneMillion = deathsPerOneMillion;
            this.Tests = tests;
            this.TestsPerOneMillion = testsPerOneMillion;
            this.Population = population;
            this.OneCasePerPeople = oneCasePerPeople;
            this.OneDeathPerPeople = oneDeathPerPeople;
            this.OneTestPerPeople = oneTestPerPeople;
            this.ActivePerOneMillion = activePerOneMillion;
            this.RecoveredPerOneMillion = recoveredPerOneMillion;
            this.CriticalPerOneMillion = criticalPerOneMillion;
            this.AffectedCountries = affectedCountries;
        }

        /// <summary>
        /// Gets or sets Updated.
        /// </summary>
        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public double? Updated { get; set; }

        /// <summary>
        /// Gets or sets Cases.
        /// </summary>
        [JsonProperty("cases", NullValueHandling = NullValueHandling.Ignore)]
        public double? Cases { get; set; }

        /// <summary>
        /// Gets or sets TodayCases.
        /// </summary>
        [JsonProperty("todayCases", NullValueHandling = NullValueHandling.Ignore)]
        public double? TodayCases { get; set; }

        /// <summary>
        /// Gets or sets Deaths.
        /// </summary>
        [JsonProperty("deaths", NullValueHandling = NullValueHandling.Ignore)]
        public double? Deaths { get; set; }

        /// <summary>
        /// Gets or sets Recovered.
        /// </summary>
        [JsonProperty("recovered", NullValueHandling = NullValueHandling.Ignore)]
        public double? Recovered { get; set; }

        /// <summary>
        /// Gets or sets TodayRecovered.
        /// </summary>
        [JsonProperty("todayRecovered", NullValueHandling = NullValueHandling.Ignore)]
        public double? TodayRecovered { get; set; }

        /// <summary>
        /// Gets or sets Active.
        /// </summary>
        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public double? Active { get; set; }

        /// <summary>
        /// Gets or sets Critical.
        /// </summary>
        [JsonProperty("critical", NullValueHandling = NullValueHandling.Ignore)]
        public double? Critical { get; set; }

        /// <summary>
        /// Gets or sets CasesPerOneMillion.
        /// </summary>
        [JsonProperty("casesPerOneMillion", NullValueHandling = NullValueHandling.Ignore)]
        public double? CasesPerOneMillion { get; set; }

        /// <summary>
        /// Gets or sets DeathsPerOneMillion.
        /// </summary>
        [JsonProperty("deathsPerOneMillion", NullValueHandling = NullValueHandling.Ignore)]
        public double? DeathsPerOneMillion { get; set; }

        /// <summary>
        /// Gets or sets Tests.
        /// </summary>
        [JsonProperty("tests", NullValueHandling = NullValueHandling.Ignore)]
        public double? Tests { get; set; }

        /// <summary>
        /// Gets or sets TestsPerOneMillion.
        /// </summary>
        [JsonProperty("testsPerOneMillion", NullValueHandling = NullValueHandling.Ignore)]
        public double? TestsPerOneMillion { get; set; }

        /// <summary>
        /// Gets or sets Population.
        /// </summary>
        [JsonProperty("population", NullValueHandling = NullValueHandling.Ignore)]
        public double? Population { get; set; }

        /// <summary>
        /// Gets or sets OneCasePerPeople.
        /// </summary>
        [JsonProperty("oneCasePerPeople", NullValueHandling = NullValueHandling.Ignore)]
        public double? OneCasePerPeople { get; set; }

        /// <summary>
        /// Gets or sets OneDeathPerPeople.
        /// </summary>
        [JsonProperty("oneDeathPerPeople", NullValueHandling = NullValueHandling.Ignore)]
        public double? OneDeathPerPeople { get; set; }

        /// <summary>
        /// Gets or sets OneTestPerPeople.
        /// </summary>
        [JsonProperty("oneTestPerPeople", NullValueHandling = NullValueHandling.Ignore)]
        public double? OneTestPerPeople { get; set; }

        /// <summary>
        /// Gets or sets ActivePerOneMillion.
        /// </summary>
        [JsonProperty("activePerOneMillion", NullValueHandling = NullValueHandling.Ignore)]
        public double? ActivePerOneMillion { get; set; }

        /// <summary>
        /// Gets or sets RecoveredPerOneMillion.
        /// </summary>
        [JsonProperty("recoveredPerOneMillion", NullValueHandling = NullValueHandling.Ignore)]
        public double? RecoveredPerOneMillion { get; set; }

        /// <summary>
        /// Gets or sets CriticalPerOneMillion.
        /// </summary>
        [JsonProperty("criticalPerOneMillion", NullValueHandling = NullValueHandling.Ignore)]
        public double? CriticalPerOneMillion { get; set; }

        /// <summary>
        /// Gets or sets AffectedCountries.
        /// </summary>
        [JsonProperty("affectedCountries", NullValueHandling = NullValueHandling.Ignore)]
        public double? AffectedCountries { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CovidAll : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is CovidAll other &&
                ((this.Updated == null && other.Updated == null) || (this.Updated?.Equals(other.Updated) == true)) &&
                ((this.Cases == null && other.Cases == null) || (this.Cases?.Equals(other.Cases) == true)) &&
                ((this.TodayCases == null && other.TodayCases == null) || (this.TodayCases?.Equals(other.TodayCases) == true)) &&
                ((this.Deaths == null && other.Deaths == null) || (this.Deaths?.Equals(other.Deaths) == true)) &&
                ((this.Recovered == null && other.Recovered == null) || (this.Recovered?.Equals(other.Recovered) == true)) &&
                ((this.TodayRecovered == null && other.TodayRecovered == null) || (this.TodayRecovered?.Equals(other.TodayRecovered) == true)) &&
                ((this.Active == null && other.Active == null) || (this.Active?.Equals(other.Active) == true)) &&
                ((this.Critical == null && other.Critical == null) || (this.Critical?.Equals(other.Critical) == true)) &&
                ((this.CasesPerOneMillion == null && other.CasesPerOneMillion == null) || (this.CasesPerOneMillion?.Equals(other.CasesPerOneMillion) == true)) &&
                ((this.DeathsPerOneMillion == null && other.DeathsPerOneMillion == null) || (this.DeathsPerOneMillion?.Equals(other.DeathsPerOneMillion) == true)) &&
                ((this.Tests == null && other.Tests == null) || (this.Tests?.Equals(other.Tests) == true)) &&
                ((this.TestsPerOneMillion == null && other.TestsPerOneMillion == null) || (this.TestsPerOneMillion?.Equals(other.TestsPerOneMillion) == true)) &&
                ((this.Population == null && other.Population == null) || (this.Population?.Equals(other.Population) == true)) &&
                ((this.OneCasePerPeople == null && other.OneCasePerPeople == null) || (this.OneCasePerPeople?.Equals(other.OneCasePerPeople) == true)) &&
                ((this.OneDeathPerPeople == null && other.OneDeathPerPeople == null) || (this.OneDeathPerPeople?.Equals(other.OneDeathPerPeople) == true)) &&
                ((this.OneTestPerPeople == null && other.OneTestPerPeople == null) || (this.OneTestPerPeople?.Equals(other.OneTestPerPeople) == true)) &&
                ((this.ActivePerOneMillion == null && other.ActivePerOneMillion == null) || (this.ActivePerOneMillion?.Equals(other.ActivePerOneMillion) == true)) &&
                ((this.RecoveredPerOneMillion == null && other.RecoveredPerOneMillion == null) || (this.RecoveredPerOneMillion?.Equals(other.RecoveredPerOneMillion) == true)) &&
                ((this.CriticalPerOneMillion == null && other.CriticalPerOneMillion == null) || (this.CriticalPerOneMillion?.Equals(other.CriticalPerOneMillion) == true)) &&
                ((this.AffectedCountries == null && other.AffectedCountries == null) || (this.AffectedCountries?.Equals(other.AffectedCountries) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Updated = {(this.Updated == null ? "null" : this.Updated.ToString())}");
            toStringOutput.Add($"this.Cases = {(this.Cases == null ? "null" : this.Cases.ToString())}");
            toStringOutput.Add($"this.TodayCases = {(this.TodayCases == null ? "null" : this.TodayCases.ToString())}");
            toStringOutput.Add($"this.Deaths = {(this.Deaths == null ? "null" : this.Deaths.ToString())}");
            toStringOutput.Add($"this.Recovered = {(this.Recovered == null ? "null" : this.Recovered.ToString())}");
            toStringOutput.Add($"this.TodayRecovered = {(this.TodayRecovered == null ? "null" : this.TodayRecovered.ToString())}");
            toStringOutput.Add($"this.Active = {(this.Active == null ? "null" : this.Active.ToString())}");
            toStringOutput.Add($"this.Critical = {(this.Critical == null ? "null" : this.Critical.ToString())}");
            toStringOutput.Add($"this.CasesPerOneMillion = {(this.CasesPerOneMillion == null ? "null" : this.CasesPerOneMillion.ToString())}");
            toStringOutput.Add($"this.DeathsPerOneMillion = {(this.DeathsPerOneMillion == null ? "null" : this.DeathsPerOneMillion.ToString())}");
            toStringOutput.Add($"this.Tests = {(this.Tests == null ? "null" : this.Tests.ToString())}");
            toStringOutput.Add($"this.TestsPerOneMillion = {(this.TestsPerOneMillion == null ? "null" : this.TestsPerOneMillion.ToString())}");
            toStringOutput.Add($"this.Population = {(this.Population == null ? "null" : this.Population.ToString())}");
            toStringOutput.Add($"this.OneCasePerPeople = {(this.OneCasePerPeople == null ? "null" : this.OneCasePerPeople.ToString())}");
            toStringOutput.Add($"this.OneDeathPerPeople = {(this.OneDeathPerPeople == null ? "null" : this.OneDeathPerPeople.ToString())}");
            toStringOutput.Add($"this.OneTestPerPeople = {(this.OneTestPerPeople == null ? "null" : this.OneTestPerPeople.ToString())}");
            toStringOutput.Add($"this.ActivePerOneMillion = {(this.ActivePerOneMillion == null ? "null" : this.ActivePerOneMillion.ToString())}");
            toStringOutput.Add($"this.RecoveredPerOneMillion = {(this.RecoveredPerOneMillion == null ? "null" : this.RecoveredPerOneMillion.ToString())}");
            toStringOutput.Add($"this.CriticalPerOneMillion = {(this.CriticalPerOneMillion == null ? "null" : this.CriticalPerOneMillion.ToString())}");
            toStringOutput.Add($"this.AffectedCountries = {(this.AffectedCountries == null ? "null" : this.AffectedCountries.ToString())}");
        }
    }
}