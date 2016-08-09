using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Security.Claims;

namespace Pacer.Authentication.Cso
{
    public class CsoSessionStore : ITicketStore
    {
        private const string SessionIdClaim = "Microsoft.AspNetCore.Authentication.Cookies-SessionId";
        private IMemoryCache cache;
        private ICsoServer server;
        private CsoOptions options;
        private TimeSpan localExpiry = TimeSpan.FromHours(1);

        /// <summary>
        /// Initializes a new instance of the CsoSessionStore class
        /// </summary>
        /// <param name="server">The CSO authentication server where logins are stored</param>
        /// <param name="options">Options for regenerating the AuthenticationTicket.</param>
        public CsoSessionStore(ICsoServer server, CsoOptions options)
        {
            this.server = server;
            this.options = options;
            this.cache = new MemoryCache(new MemoryCacheOptions());
        }

        /// <summary>
        /// Store the identity ticket and return the associated key.
        /// </summary>
        /// <param name="ticket">The identity information to store.</param>
        /// <returns>The key that can be used to retrieve the identity later.</returns>
        public async Task<string> StoreAsync(AuthenticationTicket ticket)
        {
            var sessionIdClaim = ticket.Principal.Claims.FirstOrDefault(c => c.Type.Equals(SessionIdClaim));
            var key = sessionIdClaim.Value;
            await RenewAsync(key, ticket);
            return key;
        }

        /// <summary>
        /// Tells the store that the given identity should be updated.
        /// </summary>
        /// <param name="key">Key of the identity to updated.</param>
        /// <param name="ticket">The identity information to store.</param>
        public Task RenewAsync(string key, AuthenticationTicket ticket)
        {
            var opt = new MemoryCacheEntryOptions();
            opt.SetAbsoluteExpiration(localExpiry);

            cache.Set(key, ticket, opt);

            return Task.FromResult(0);
        }

        /// <summary>
        /// Retrieves an identity from the store for the given key. If not found locally,
        /// checks the remote CSO server to revalidate the identity.
        /// </summary>
        /// <param name="key">The key associated with the identity.</param>
        /// <returns>The identity associated with the given key, or null if not found.</returns>
        public async Task<AuthenticationTicket> RetrieveAsync(string key)
        {
            // TODO: how do we get an IP address here?
            var ticket = RetrieveLocal(key);
            if (ticket != null) return ticket;

            ticket = await RetrieveRemote(null, key, null);
            if (ticket != null) await StoreAsync(ticket);

            return ticket;
        }

        /// <summary>
        /// Retrieves an identity from the store for the given key.
        /// </summary>
        /// <param name="key">The key associated with the identity.</param>
        /// <returns>The identity associated with the given key, or null if not found.</returns>
        private AuthenticationTicket RetrieveLocal(string key)
        {
            AuthenticationTicket ticket;
            cache.TryGetValue(key, out ticket);
            return ticket;
        }

        /// <summary>
        /// Revalidates an identity from the remote server.
        /// </summary>
        /// <param name="ip">The IP address of the client agent</param>
        /// <param name="key">The key associated with the identity.</param>
        /// <param name="clientCode">The client code requested</param>
        /// <returns>The identity associated with the given key, or null if not found.</returns>
        private async Task<AuthenticationTicket> RetrieveRemote(string ip, string key, string clientCode)
        {
            CsoResponse response;
            var success = await server.TryRevalidateAsync(ip, key, clientCode, out response);
            if (!success) return null;

            var principal = response.AsPrincipal(options);

            // set the SessionIdClaim so that the cookie can be correctly set and reset
            ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(SessionIdClaim, response.NextGenCSO, ClaimValueTypes.String, options.ClaimsIssuer));

            return new AuthenticationTicket(principal, null, options.AuthenticationScheme);
        }

        /// <summary>
        /// Remove the identity associated with the given key.
        /// </summary>
        /// <param name="key">The key associated with the identity.</param>
        public Task RemoveAsync(string key)
        {
            cache.Remove(key);
            return Task.FromResult(0);
        }
    }
}