// Original copyright:
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

// Modified by eTelic Inc for U.S. Courts
// Changed name, default values in constructor, ITicketStore definition, and ClientCodeCookieName.

using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Builder;

namespace Pacer.Authentication.Cso
{
    /// <summary>
    /// Configuration options for <see cref="CsoMiddleware"/>.
    /// </summary>
    public class CsoOptions : CookieAuthenticationOptions, IOptions<CsoOptions>
    {
        private string _cookieName;

        /// <summary>
        /// Create an instance of the options initialized with the default values
        /// </summary>
        public CsoOptions()
            :base()
        {
            AuthenticationScheme = CsoDefaults.AuthenticationScheme;
            AutomaticAuthenticate = true;
            ReturnUrlParameter = CsoDefaults.ReturnUrlParameter;
            ExpireTimeSpan = TimeSpan.FromHours(12);
            SlidingExpiration = false;
            CookieHttpOnly = true;
            CookieSecure = CookieSecurePolicy.SameAsRequest;
            SystemClock = new SystemClock();
            Events = new CsoAuthenticationEvents();

            ClientCodeCookieName = CsoDefaults.ClientCodeCookieName;
            this.ClaimsIssuer = "CSO";
        }

        public void SetCsoServer(ICsoServer server)
        {
            // TODO: I don't think a method in an IOptions is best practice, we should pass this server in elsewhere.
            this.SessionStore = new CsoSessionStore(server, this);
            this.TicketDataFormat = new CsoDataFormat(this);
        }

        public string ClientCodeCookieName { get; set; }

        /// <summary>
        /// An optional container in which to store the identity across requests. When used, only a session identifier is sent
        /// to the client. This can be used to mitigate potential problems with very large identities.
        /// </summary>
        new public ITicketStore SessionStore { get; set; }

        CsoOptions IOptions<CsoOptions>.Value
        {
            get
            {
                return this;
            }
        }
    }
}
