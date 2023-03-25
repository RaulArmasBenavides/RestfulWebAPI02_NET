using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace RestfulWebAPI02_NET.Credentials
{
    public class AppOAuthProvider : OAuthAuthorizationServerProvider
    {

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        //TEST
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Oriigin", new[] { "*" });
            var acceso = ((context.UserName == "admin" && context.Password == "123") || (context.UserName == "user" & context.Password == "222"));

            if (acceso == false)
            {
                context.SetError("Sin acceso", "Usuario o PW incorrecto");
            }
            else
            {
                ClaimsIdentity identidad = new ClaimsIdentity(context.Options.AuthenticationType);
                identidad.AddClaim(new Claim(ClaimTypes.Name, context.Password));
                //
                if (context.UserName =="admin" && context.Password=="123")
                {
                    identidad.AddClaim(new Claim(ClaimTypes.Role, "ADMINISTRADOR"));
                    context.Validated(identidad);
                }
                if (context.UserName == "user" && context.Password == "222")
                {
                    identidad.AddClaim(new Claim(ClaimTypes.Role, "USUARIO"));
                    context.Validated(identidad);
                }
            }
        }

        /// <summary>
        /// Grant resource owner credentials overload method.
        /// </summary>
        /// <param name="context">Context parameter</param>
        /// <returns>Returns when task is completed</returns>
        //public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        //{
        //    // Initialization.
        //    string usernameVal = context.UserName;
        //    string passwordVal = context.Password;
        //    var user = "raul";// this.databaseManager.LoginByUsernamePassword(usernameVal, passwordVal).ToList();

        //    // Verification.
        //    if (user == null || user.Count() <= 0)
        //    {
        //        // Settings.
        //        context.SetError("invalid_grant", "The user name or password is incorrect.");

        //        // Retuen info.
        //        return;
        //    }

        //    // Initialization.
        //    var claims = new List<Claim>();
        //    var userInfo = user.FirstOrDefault();

        //    // Setting
        //    claims.Add(new Claim(ClaimTypes.Name,"Raúl"));

        //    // Setting Claim Identities for OAUTH 2 protocol.
        //    ClaimsIdentity oAuthClaimIdentity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
        //    ClaimsIdentity cookiesClaimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationType);

        //    //// Setting user authentication.
        //    //AuthenticationProperties properties = CreateProperties(userInfo.username);
        //    //AuthenticationTicket ticket = new AuthenticationTicket(oAuthClaimIdentity, properties);

        //    // Grant access to authorize user.
        //    context.Validated(oAuthClaimIdentity);
        //    context.Request.Context.Authentication.SignIn(cookiesClaimIdentity);
        //}
    }
}