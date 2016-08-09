using System.Threading.Tasks;

namespace Pacer.Authentication.Cso
{
    /// <summary>
    /// Interface representing a CSO authentication server
    /// </summary>
    public interface ICsoServer
    {
        /// <summary>
        /// Attempt to revalidate a user with the given credentials.
        /// </summary>
        /// <param name="ip">The IP address of the client agent</param>
        /// <param name="key">The key associated with the identity.</param>
        /// <param name="clientCode">The client code requested</param>
        /// <param name="response">The response from the CSO server</param>
        /// <returns>A boolean indicating whether the revalidation succeded.</returns>
        Task<bool> TryRevalidateAsync(string ip, string key, string clientCode, out CsoResponse response);
    }
}