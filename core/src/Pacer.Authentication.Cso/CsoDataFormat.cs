using System;
using Microsoft.AspNetCore.Authentication;
using System.Linq;
using System.Security.Claims;

namespace Pacer.Authentication.Cso
{
    /// <summary>
    /// Instead of protecting the cookie by encrypting it, just reuse the NextGenCSO
    /// authentication token value as the cookie value. You must also set a value for
    /// SessionStore if you are going to use this as a TicketDataFormat.
    /// </summary>
    public class CsoDataFormat : ISecureDataFormat<AuthenticationTicket>
    {
        /// <summary>
        /// Used by Microsoft.AspNetCore.Authentication.Cookies to identify sessions.
        /// </summary>
        private const string SessionIdClaim = "Microsoft.AspNetCore.Authentication.Cookies-SessionId";
        public CsoOptions Options { get; set; }

        /// <summary>
        /// Initializes an instance of the CsoDataFormat class.
        /// </summary>
        /// <param name="options"></param>
        public CsoDataFormat(CsoOptions options)
        {
            this.Options = options;
        }

        /// <summary>
        /// Protects the ticket by serializing only the NextGenCSO token.
        /// </summary>
        /// <param name="data">Ticket to protect</param>
        /// <returns>The NextGenCSO token</returns>
        public string Protect(AuthenticationTicket data)
        {
            var sessionIdClaim = data.Principal.Claims.FirstOrDefault(c => c.Type.Equals(SessionIdClaim));
            return sessionIdClaim.Value;
        }

        /// <summary>
        /// Protects the ticket by serializing only the NextGenCSO token.
        /// </summary>
        /// <param name="data">Ticket to protect</param>
        /// <param name="purpose">Unused</param>
        /// <returns>The NextGenCSO token</returns>
        public string Protect(AuthenticationTicket data, string purpose)
        {
            return Protect(data);
        }

        /// <summary>
        /// Unprotects the ticket by reconstructing a ticket containing only the NextGenCSO token.
        /// </summary>
        /// <param name="protectedText">The NextGenCSO token</param>
        /// <returns>A ticket with a single claim containing the NextGenCSO token</returns>
        public AuthenticationTicket Unprotect(string protectedText)
        {
            // reconstruct the authentication ticket the same way as Microsoft.AspNetCore.Authentication.Cookies
            var principal = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new[] { new Claim(SessionIdClaim, protectedText, ClaimValueTypes.String, Options.ClaimsIssuer) },
                    Options.AuthenticationScheme));
            return new AuthenticationTicket(principal, null, Options.AuthenticationScheme);
        }

        /// <summary>
        /// Unprotects the ticket by reconstructing a ticket containing only the NextGenCSO token.
        /// </summary>
        /// <param name="protectedText">The NextGenCSO token</param>
        /// <param name="purpose">Unused</param>
        /// <returns>A ticket with a single claim containing the NextGenCSO token</returns>
        public AuthenticationTicket Unprotect(string protectedText, string purpose)
        {
            return Unprotect(protectedText);
        }
    }
}