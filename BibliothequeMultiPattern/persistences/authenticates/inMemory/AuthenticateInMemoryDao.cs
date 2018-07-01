using BibliothequeMultiPattern.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.persistences.authenticator.adapter
{
    public class AuthenticateInMemoryDao
    {
        public string id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Role role { get; set; }

        public AuthenticateInMemoryDao(string id, string login, string password, Role role)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.role = role;
        }
    }
}
