// Original copyright:
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

// Modified by eTelic Inc for U.S. Courts
// Changed default values.

using Microsoft.AspNetCore.Http;

namespace Pacer.Authentication.Cso
{
    /// <summary>
    /// Default values related to CSO authentication middleware
    /// </summary>
    public static class CsoDefaults
    {
        /// <summary>
        /// The default value used for CsoOptions.AuthenticationScheme
        /// </summary>
        public const string AuthenticationScheme = "CSO";

        /// <summary>
        /// The prefix used to provide a default CsoOptions.CookieName
        /// </summary>
        public static readonly string CookiePrefix = "NextGen";

        /// <summary>
        /// The prefix used to provide a default CsoOptions.CookieName
        /// </summary>
        public static readonly string ClientCodeCookieName = "PacerClientCode";

        /// <summary>
        /// The default value used by CsoMiddleware for the
        /// CsoOptions.LoginPath
        /// </summary>
        public static readonly PathString LoginPath = new PathString("/Account/Login");

        /// <summary>
        /// The default value used by CsoMiddleware for the
        /// CsoOptions.LogoutPath
        /// </summary>
        public static readonly PathString LogoutPath = new PathString("/Account/Logout");

        /// <summary>
        /// The default value used by CsoMiddleware for the
        /// CsoOptions.AccessDeniedPath
        /// </summary>
        public static readonly PathString AccessDeniedPath = new PathString("/Account/AccessDenied");

        /// <summary>
        /// The default value of the CsoOptions.ReturnUrlParameter
        /// </summary>
        public static readonly string ReturnUrlParameter = "ReturnUrl";
    }
}
