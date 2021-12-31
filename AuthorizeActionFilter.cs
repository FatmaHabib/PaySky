using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PaySky
{
    public class AuthorizeActionFilter : IAuthorizationFilter
    {
        public AuthorizeActionFilter()
        {
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string UserToken = null;
            if (context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                 UserToken = new JwtSecurityTokenHandler().ReadToken(context.HttpContext.Request.Headers["Authorization"]).ToString();
            }
                bool isAuthorized = UserToken!=null ? true : false;
            if (!isAuthorized)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    
    }
}
