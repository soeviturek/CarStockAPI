using CarStockAPI.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace CarStockAPI
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {

        readonly IDealers _dealerService;
        public ApiKeyAuthenticationHandler(
            IDealers dealerService,
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
            _dealerService = dealerService;
        }

        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.Headers["WWW-Authenticate"] = "ApiKey";//Basic
            return base.HandleChallengeAsync(properties);
        }
        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string key = null;
            try
            {
                key = Request.Headers["x-api-key"];
                if (String.IsNullOrEmpty(key))
                {
                    throw new ArgumentException("Invalid Key, authentication failed!");
                }
                //key = AuthenticationHeaderValue.Parse(Request.Headers["x-api-key"]).ToString();
                //key = authHeader.Parameter;
                //Console.WriteLine(authHeader);
                //var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
                //key = credentials.FirstOrDefault();

                if (!_dealerService.CheckKey(key))
                {
                    throw new ArgumentException("Invalid Key, authentication failed!");
                }

            }
            catch (Exception ex)
            {
                
                return AuthenticateResult.Fail(ex.Message);
            }
            var claims = new[] { 
                new Claim(ClaimTypes.Name,key)
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }

    }
}
