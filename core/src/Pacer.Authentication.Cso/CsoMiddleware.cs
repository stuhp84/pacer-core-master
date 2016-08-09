// Original copyright:
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

// Modified by eTelic Inc for U.S. Courts
// Changed name, handler, constructor.

using System;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Pacer.Authentication.Cso
{
    public class CsoMiddleware : AuthenticationMiddleware<CsoOptions>
    {
        public CsoMiddleware(
            RequestDelegate next,
            IDataProtectionProvider dataProtectionProvider,
            ILoggerFactory loggerFactory,
            UrlEncoder urlEncoder,
            IOptions<CsoOptions> options)
            : base(next, options, loggerFactory, urlEncoder)
        {
            if (dataProtectionProvider == null)
            {
                throw new ArgumentNullException(nameof(dataProtectionProvider));
            }

            if (Options.Events == null)
            {
                Options.Events = new CsoAuthenticationEvents();
            }
            if (String.IsNullOrEmpty(Options.CookieName))
            {
                Options.CookieName = CsoDefaults.CookiePrefix + Options.AuthenticationScheme;
            }
            if (Options.TicketDataFormat == null)
            {
                var provider = Options.DataProtectionProvider ?? dataProtectionProvider;
                var dataProtector = provider.CreateProtector(typeof(CsoMiddleware).FullName, Options.AuthenticationScheme, "v2");
                Options.TicketDataFormat = new TicketDataFormat(dataProtector);
            }
            if (Options.CookieManager == null)
            {
                Options.CookieManager = new ChunkingCookieManager();
            }
            if (!Options.LoginPath.HasValue)
            {
                Options.LoginPath = CsoDefaults.LoginPath;
            }
            if (!Options.LogoutPath.HasValue)
            {
                Options.LogoutPath = CsoDefaults.LogoutPath;
            }
            if (!Options.AccessDeniedPath.HasValue)
            {
                Options.AccessDeniedPath = CsoDefaults.AccessDeniedPath;
            }
        }

        protected override AuthenticationHandler<CsoOptions> CreateHandler()
        {
            return new CsoHandler();
        }
    }
}