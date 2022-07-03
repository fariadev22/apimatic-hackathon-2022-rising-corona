// <copyright file="APIEntityCodeGeneration.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ApimaticAPI.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ApimaticAPI.Standard;
    using ApimaticAPI.Standard.Utilities;
    using JsonSubTypes;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// APIEntityCodeGeneration.
    /// </summary>
    public class APIEntityCodeGeneration : CodeGeneration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="APIEntityCodeGeneration"/> class.
        /// </summary>
        public APIEntityCodeGeneration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="APIEntityCodeGeneration"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="template">template.</param>
        /// <param name="generatedFile">generatedFile.</param>
        /// <param name="generatedOn">generatedOn.</param>
        /// <param name="hashCode">hashCode.</param>
        /// <param name="codeGenerationSource">codeGenerationSource.</param>
        /// <param name="codeGenVersion">codeGenVersion.</param>
        /// <param name="success">success.</param>
        /// <param name="apiEntityId">apiEntityId.</param>
        public APIEntityCodeGeneration(
            string id,
            Models.Platforms template,
            string generatedFile,
            DateTime generatedOn,
            string hashCode,
            string codeGenerationSource,
            string codeGenVersion,
            bool success,
            string apiEntityId)
            : base(
                id,
                template,
                generatedFile,
                generatedOn,
                hashCode,
                codeGenerationSource,
                codeGenVersion,
                success)
        {
            this.ApiEntityId = apiEntityId;
        }

        /// <summary>
        /// Unique API Entity Identifier
        /// </summary>
        [JsonProperty("apiEntityId")]
        public string ApiEntityId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"APIEntityCodeGeneration : ({string.Join(", ", toStringOutput)})";
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

            return obj is APIEntityCodeGeneration other &&
                ((this.ApiEntityId == null && other.ApiEntityId == null) || (this.ApiEntityId?.Equals(other.ApiEntityId) == true)) &&
                base.Equals(obj);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ApiEntityId = {(this.ApiEntityId == null ? "null" : this.ApiEntityId == string.Empty ? "" : this.ApiEntityId)}");

            base.ToString(toStringOutput);
        }
    }
}