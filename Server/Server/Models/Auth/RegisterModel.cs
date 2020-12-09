using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Auth
{
    public class RegisterModel
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsDoctor { get; set; }
    }
}
