// <copyright file="Platforms.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ApimaticAPI.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using ApimaticAPI.Standard;
    using ApimaticAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Platforms.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Platforms
    {
        /// <summary>
        ///.NET Standard Library
        /// CSNETSTANDARDLIB.
        /// </summary>
        [EnumMember(Value = "CS_NET_STANDARD_LIB")]
        CSNETSTANDARDLIB,

        /// <summary>
        ///.NET Portable Library
        /// CSPORTABLENETLIB.
        /// </summary>
        [EnumMember(Value = "CS_PORTABLE_NET_LIB")]
        CSPORTABLENETLIB,

        /// <summary>
        ///.NET Windows Platform
        /// CSUNIVERSALWINDOWSPLATFORMLIB.
        /// </summary>
        [EnumMember(Value = "CS_UNIVERSAL_WINDOWS_PLATFORM_LIB")]
        CSUNIVERSALWINDOWSPLATFORMLIB,

        /// <summary>
        ///Android
        /// JAVAGRADLEANDROIDLIB.
        /// </summary>
        [EnumMember(Value = "JAVA_GRADLE_ANDROID_LIB")]
        JAVAGRADLEANDROIDLIB,

        /// <summary>
        ///Objective C  - iOS
        /// OBJCCOCOATOUCHIOSLIB.
        /// </summary>
        [EnumMember(Value = "OBJC_COCOA_TOUCH_IOS_LIB")]
        OBJCCOCOATOUCHIOSLIB,

        /// <summary>
        ///JAVA
        /// JAVAECLIPSEJRELIB.
        /// </summary>
        [EnumMember(Value = "JAVA_ECLIPSE_JRE_LIB")]
        JAVAECLIPSEJRELIB,

        /// <summary>
        ///PHP
        /// PHPGENERICLIB.
        /// </summary>
        [EnumMember(Value = "PHP_GENERIC_LIB")]
        PHPGENERICLIB,

        /// <summary>
        ///Python
        /// PYTHONGENERICLIB.
        /// </summary>
        [EnumMember(Value = "PYTHON_GENERIC_LIB")]
        PYTHONGENERICLIB,

        /// <summary>
        ///Ruby
        /// RUBYGENERICLIB.
        /// </summary>
        [EnumMember(Value = "RUBY_GENERIC_LIB")]
        RUBYGENERICLIB,

        /// <summary>
        ///Angular JS
        /// ANGULARJAVASCRIPTLIB.
        /// </summary>
        [EnumMember(Value = "ANGULAR_JAVASCRIPT_LIB")]
        ANGULARJAVASCRIPTLIB,

        /// <summary>
        ///Node JS
        /// NODEJAVASCRIPTLIB.
        /// </summary>
        [EnumMember(Value = "NODE_JAVASCRIPT_LIB")]
        NODEJAVASCRIPTLIB,

        /// <summary>
        ///GO Language
        /// GOGENERICLIB.
        /// </summary>
        [EnumMember(Value = "GO_GENERIC_LIB")]
        GOGENERICLIB,

        /// <summary>
        ///HTTP CURL
        /// HTTPCURLV1.
        /// </summary>
        [EnumMember(Value = "HTTP_CURL_V1")]
        HTTPCURLV1
    }
}