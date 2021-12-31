using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaySky.Models
{
    public class UserModel
    {
        public int ID { set; get; }
        public string UserName { set; get; }

        public string Password { set; get; }
    }
}
