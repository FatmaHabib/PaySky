using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaySky
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute()
       : base(typeof(AuthorizeActionFilter))
        {
            Arguments = new object[] {  };
        }
    }
}
