// <copyright file="CountryInfo.cs" company="APIMatic">
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
    /// CountryInfo.
    /// </summary>
    public class CountryInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryInfo"/> class.
        /// </summary>
        public CountryInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryInfo"/> class.
        /// </summary>
        /// <param name="id">_id.</param>
        /// <param name="iso2">iso2.</param>
        /// <param name="iso3">iso3.</param>
        /// <param name="lat">lat.</param>
        /// <param name="mLong">long.</param>
        /// <param name="flag">flag.</param>
        public CountryInfo(
            double? id = null,
            string iso2 = null,
            string iso3 = null,
            double? lat = null,
            double? mLong = null,
            string flag = null)
        {
            this.Id = id;
            this.Iso2 = iso2;
            this.Iso3 = iso3;
            this.Lat = lat;
            this.MLong = mLong;
            this.Flag = flag;
        }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
        public double? Id { get; set; }

        /// <summary>
        /// Gets or sets Iso2.
        /// </summary>
        [JsonProperty("iso2", NullValueHandling = NullValueHandling.Ignore)]
        public string Iso2 { get; set; }

        /// <summary>
        /// Gets or sets Iso3.
        /// </summary>
        [JsonProperty("iso3", NullValueHandling = NullValueHandling.Ignore)]
        public string Iso3 { get; set; }

        /// <summary>
        /// Gets or sets Lat.
        /// </summary>
        [JsonProperty("lat", NullValueHandling = NullValueHandling.Ignore)]
        public double? Lat { get; set; }

        /// <summary>
        /// Gets or sets MLong.
        /// </summary>
        [JsonProperty("long", NullValueHandling = NullValueHandling.Ignore)]
        public double? MLong { get; set; }

        /// <summary>
        /// Gets or sets Flag.
        /// </summary>
        [JsonProperty("flag", NullValueHandling = NullValueHandling.Ignore)]
        public string Flag { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CountryInfo : ({string.Join(", ", toStringOutput)})";
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

            return obj is CountryInfo other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Iso2 == null && other.Iso2 == null) || (this.Iso2?.Equals(other.Iso2) == true)) &&
                ((this.Iso3 == null && other.Iso3 == null) || (this.Iso3?.Equals(other.Iso3) == true)) &&
                ((this.Lat == null && other.Lat == null) || (this.Lat?.Equals(other.Lat) == true)) &&
                ((this.MLong == null && other.MLong == null) || (this.MLong?.Equals(other.MLong) == true)) &&
                ((this.Flag == null && other.Flag == null) || (this.Flag?.Equals(other.Flag) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id.ToString())}");
            toStringOutput.Add($"this.Iso2 = {(this.Iso2 == null ? "null" : this.Iso2 == string.Empty ? "" : this.Iso2)}");
            toStringOutput.Add($"this.Iso3 = {(this.Iso3 == null ? "null" : this.Iso3 == string.Empty ? "" : this.Iso3)}");
            toStringOutput.Add($"this.Lat = {(this.Lat == null ? "null" : this.Lat.ToString())}");
            toStringOutput.Add($"this.MLong = {(this.MLong == null ? "null" : this.MLong.ToString())}");
            toStringOutput.Add($"this.Flag = {(this.Flag == null ? "null" : this.Flag == string.Empty ? "" : this.Flag)}");
        }
    }
}