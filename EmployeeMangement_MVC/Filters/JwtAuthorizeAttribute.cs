using EmployeeMangement_MVC.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace EmployeeMangement_MVC.Filters
{
    public class JwtAuthorizeAttribute:ActionFilterAttribute
    {
        private readonly string _SecretKey;
        public JwtAuthorizeAttribute()
        {
            var obj = AppConfigHelper.GetConfigValue();
            _SecretKey=obj.Result.SecretKey;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            var token = session.GetString("JWTToken"); // Get JWT from session

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedResult(); // No token → Block access
                return;
            }

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_SecretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                tokenHandler.ValidateToken(token, validationParameters, out _);
            }
            catch
            {
                context.Result = new UnauthorizedResult(); // Invalid token → Block access
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
