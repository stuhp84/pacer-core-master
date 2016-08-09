// Original copyright:
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

// Modified by eTelic Inc for U.S. Courts
// Changed name.

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacer.Authentication.Cso
{
    /// <summary>
    /// Extension methods to add CSO authentication to an HTTP application pipeline.
    /// </summary>
    public static class CsoAppBuilderExtensions
    {
        /// <summary>
        /// Adds the <see cref="CsoMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables CSO authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseCsoAuthentication(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMiddleware<CsoMiddleware>();
        }

        /// <summary>
        /// Adds the <see cref="CsoMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables CSO authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <param name="options">A <see cref="CsoOptions"/> that specifies options for the middleware.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseCsoAuthentication(this IApplicationBuilder app, CsoOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<CsoMiddleware>(Options.Create(options));
        }
    }
}
