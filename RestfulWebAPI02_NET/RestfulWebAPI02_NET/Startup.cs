using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using RestfulWebAPI02_NET.Credentials;
using System;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(RestfulWebAPI02_NET.Startup))]

namespace RestfulWebAPI02_NET
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            ConfigurarOauth(app);
            app.UseWebApi(config);
        }

        public void ConfigurarOauth(IAppBuilder app)
        {
            // Configure the application for OAuth based flow
            //var PublicClientId = "self";
            OAuthAuthorizationServerOptions OAuthOptions = new OAuthAuthorizationServerOptions
            {
                Provider = new AppOAuthProvider(),
                TokenEndpointPath = new PathString("/recuperartoken"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(4),
                AllowInsecureHttp = true //Don't do this in production ONLY FOR DEVELOPING: ALLOW INSECURE HTTP!
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthAuthorizationServer(OAuthOptions);

            OAuthBearerAuthenticationOptions opcionesauth =
                new OAuthBearerAuthenticationOptions()
                {
                    AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active
                };
            app.UseOAuthBearerAuthentication(opcionesauth);
        }
    }
}
