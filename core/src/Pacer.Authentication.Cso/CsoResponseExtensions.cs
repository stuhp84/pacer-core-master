using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pacer.Authentication.Cso
{
    /// <summary>
    /// Extension methods for the CsoResponse class.
    /// </summary>
    public static class CsoResponseExtensions
    {
        public static ClaimsPrincipal AsPrincipal(this CsoResponse response, CsoOptions options)
        {
            var claims = response.AsClaims(options.ClaimsIssuer);
            var identity = new ClaimsIdentity(claims, options.AuthenticationScheme);
            return new ClaimsPrincipal(identity);
        }

        /// <summary>
        /// Generates a sequence of claims based upon this response
        /// </summary>
        /// <param name="response"></param>
        /// <param name="issuer">Entity issuing the claim</param>
        /// <returns></returns>
        public static IEnumerable<Claim> AsClaims(this CsoResponse response, string issuer)
        {
            var r = response;
            if (r.LoginId != null)          yield return new Claim("LoginId", r.LoginId, ClaimValueTypes.String, issuer);
                                            yield return new Claim("LoginResult", r.LoginResult.ToString(), ClaimValueTypes.Integer32, issuer);
            if (r.ErrorDescription != null) yield return new Claim("ErrorDescription", r.ErrorDescription, ClaimValueTypes.String, issuer);
            if (r.NextGenCSO != null)       yield return new Claim("NextGenCSO", r.NextGenCSO, ClaimValueTypes.String, issuer);
            if (r.PacerSession != null)     yield return new Claim("PacerSession", r.PacerSession, ClaimValueTypes.String, issuer);
            if (r.FirstName != null)        yield return new Claim("FirstName", r.FirstName, ClaimValueTypes.String, issuer);
            if (r.LastName != null)         yield return new Claim("LastName", r.LastName, ClaimValueTypes.String, issuer);
            if (r.ClientCode != null)       yield return new Claim("ClientCode", r.ClientCode, ClaimValueTypes.String, issuer);
            if (r.ClientCodeDescription != null) yield return new Claim("ClientCodeDescription", r.ClientCodeDescription, ClaimValueTypes.String, issuer);
            if (r.ClientValidation != null) yield return new Claim("ClientValidation", r.ClientValidation, ClaimValueTypes.String, issuer);
            if (r.UserIPAddress != null)    yield return new Claim("UserIPAddress", r.UserIPAddress, ClaimValueTypes.String, issuer);
            if (r.Expires != null)          yield return new Claim("Expires", r.Expires, ClaimValueTypes.String, issuer);
                                            yield return new Claim("TimeToLive", r.TimeToLive.ToString(), ClaimValueTypes.Integer32, issuer);
            if (r.FirmId != null)           yield return new Claim("FirmId", r.FirmId, ClaimValueTypes.String, issuer);
            if (r.CSOId != null)            yield return new Claim("CSOId", r.CSOId, ClaimValueTypes.String, issuer);
                                            yield return new Claim("PacerStatus", r.PacerStatus.ToString(), ClaimValueTypes.Integer32, issuer);
            if (r.UserMsg != null)          yield return new Claim("UserMsg", r.UserMsg, ClaimValueTypes.String, issuer);
            if (r.ExemptStatus != null)     yield return new Claim("ExemptStatus", r.ExemptStatus, ClaimValueTypes.String, issuer);
            if (r.ExcemptJurisdiction != null) yield return new Claim("ExcemptJurisdiction", r.ExcemptJurisdiction, ClaimValueTypes.String, issuer);
            if (r.Type != null)             yield return new Claim("Type", r.Type, ClaimValueTypes.String, issuer);
            if (r.FilerStatus != null)      yield return new Claim("FilerStatus", r.FilerStatus, ClaimValueTypes.String, issuer);
        }
    }
}
