using BibliothequeMultiPattern.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.services.authenticator.model
{
    public class Authenticate
    {
        public AuthenticateId authenticateId { get; }
        public string login { get; }
        public Role role { get; }

        public Authenticate(AuthenticateId authenticateId, string login, Role role)
        {
            this.authenticateId = authenticateId;
            this.login = login;
            this.role = role;
        }
    }
}
