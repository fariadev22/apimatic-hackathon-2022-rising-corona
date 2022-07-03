// <copyright file="BasicAuthManager.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ApimaticAPI.Standard.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using ApimaticAPI.Standard.Http.Request;

    /// <summary>
    /// BasicAuthManager Class.
    /// </summary>
    internal class BasicAuthManager : IBasicAuthCredentials, IAuthManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IrisBasicAuthManager"/> class.
        /// </summary>
        /// <param name="username"> Username.</param>
        /// <param name="password"> Password.</param>
        public BasicAuthManager(string username, string password)
        {
            this.Email = username;
            this.Password = password;
        }

        /// <summary>
        /// Gets email.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets password.
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Check if credentials match.
        /// </summary>
        /// <param name="email"> email.</param>
        /// <param name="password"> password.</param>
        /// <returns> The boolean value.</returns>
        public bool Equals(string email, string password)
        {
            return email.Equals(this.Email)
                    && password.Equals(this.Password);
        }

        /// <summary>
        /// Adds authentication to the given HttpRequest.
        /// </summary>
        /// <param name="httpRequest">Http Request.</param>
        /// <returns>Returns the httpRequest after adding authentication.</returns>
        public HttpRequest Apply(HttpRequest httpRequest)
        {
            string authCredentials = this.Email + ":" + this.Password;
            byte[] data = Encoding.ASCII.GetBytes(authCredentials);
            httpRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(data);
            return httpRequest;
        }

        /// <summary>
        /// Adds authentication to the given HttpRequest.
        /// </summary>
        /// <param name="httpRequest">Http Request.</param>
        /// <returns>Returns the httpRequest after adding authentication.</returns>
        public Task<HttpRequest> ApplyAsync(HttpRequest httpRequest)
        {
            string authCredentials = this.Email + ":" + this.Password;
            byte[] data = Encoding.ASCII.GetBytes(authCredentials);
            httpRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(data);
            return Task.FromResult(httpRequest);
        }
    }
}