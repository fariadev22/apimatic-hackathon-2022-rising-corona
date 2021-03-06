// <copyright file="ControllerTestBase.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace DiseaseShAPI.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DiseaseShAPI.Standard;
    using DiseaseShAPI.Standard.Http.Client;
    using DiseaseShAPI.Standard.Models;
    using DiseaseShAPI.Tests.Helpers;
    using NUnit.Framework;

    /// <summary>
    /// ControllerTestBase Class.
    /// </summary>
    [TestFixture]
    public class ControllerTestBase
    {
        /// <summary>
        /// Assert precision.
        /// </summary>
        protected const double AssertPrecision = 0.1;

        /// <summary>
        /// Gets HttpCallBackHandler.
        /// </summary>
        internal HttpCallBack HttpCallBackHandler { get; private set; }

        /// <summary>
        /// Gets DiseaseShAPIClient Client.
        /// </summary>
        protected DiseaseShAPIClient Client { get; private set; }

        /// <summary>
        /// Set up the client.
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            this.HttpCallBackHandler = new HttpCallBack();
            this.Client = DiseaseShAPIClient.CreateFromEnvironment().ToBuilder()
                .HttpCallBack(this.HttpCallBackHandler)
                .Build();
        }
    }
}