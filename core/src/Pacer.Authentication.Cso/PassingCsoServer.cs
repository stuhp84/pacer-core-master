using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacer.Authentication.Cso
{
    /// <summary>
    /// A mock CSO server that always successfully revalidates a user's credentials.
    /// </summary>
    public class PassingCsoServer : ICsoServer
    {
        /// <summary>
        /// Always revalidate the user regardless of the given credentials.
        /// </summary>
        /// <param name="ip">The IP address of the client agent</param>
        /// <param name="key">The key associated with the identity.</param>
        /// <param name="clientCode">The client code requested</param>
        /// <param name="response">The response from the CSO server</param>
        /// <returns>A boolean indicating whether the revalidation succeded.</returns>
        public virtual Task<bool> TryRevalidateAsync(string ip, string key, string clientCode, out CsoResponse response)
        {
            response = CreateResponse();
            var r = true;
            return Task.FromResult(r);
        }

        /// <summary>
        /// Create a mock response object.
        /// </summary>
        /// <returns>A mock response object.</returns>
        protected CsoResponse CreateResponse()
        {
            var r = new CsoResponse();
            r.LoginId = "jane.doe";
            r.LoginResult = 0;
            r.ErrorDescription = null;
            r.NextGenCSO = "asdc83ioslclskdlk8492kld";
            r.PacerSession = "asodcsocosdncsldk";
            r.FirstName = "Jane";
            r.LastName = "Doe";
            r.ClientCode = "94938";
            r.ClientCodeDescription = "5 numeric characters";
            r.ClientValidation = @"^\d\d\d\d\d$";
            r.UserIPAddress = "12.34.56.890";
            r.Expires = DateTime.UtcNow.AddDays(0.5).ToString("r");
            r.TimeToLive = (int)Math.Round(TimeSpan.FromHours(12).TotalMinutes);
            r.FirmId = null;
            r.CSOId = "3384838";
            r.PacerStatus = 0;
            r.UserMsg = null;
            r.ExemptStatus = "n";
            r.ExcemptJurisdiction = null;
            r.Type = "P";
            r.FilerStatus = "0";
            return r;
        }
    }
}
