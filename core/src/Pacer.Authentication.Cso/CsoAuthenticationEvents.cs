using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Pacer.Authentication.Cso
{
    public class CsoAuthenticationEvents : CookieAuthenticationEvents
    {
        public override Task RedirectToAccessDenied(CookieRedirectContext context)
        {
            return base.RedirectToAccessDenied(context);
        }

        public override Task RedirectToLogin(CookieRedirectContext context)
        {
            return base.RedirectToLogin(context);
        }

        public override Task RedirectToLogout(CookieRedirectContext context)
        {
            return base.RedirectToLogout(context);
        }

        public override Task RedirectToReturnUrl(CookieRedirectContext context)
        {
            return base.RedirectToReturnUrl(context);
        }

        public override Task SignedIn(CookieSignedInContext context)
        {
            return base.SignedIn(context);
        }

        public override Task SigningIn(CookieSigningInContext context)
        {
            return base.SigningIn(context);
        }

        public override Task SigningOut(CookieSigningOutContext context)
        {
            return base.SigningOut(context);
        }

        public override Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            return base.ValidatePrincipal(context);
        }
    }
}