using BibliothequeMultiPattern.services.authenticator.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.model
{
    public class User
    {
        public UserId id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public AuthenticateId authenticatedId { get; set; }

        public User(UserId id, string name, string firstName, AuthenticateId authenticatedId)
        {
            this.id = id;
            Name = name;
            FirstName = firstName;
            this.authenticatedId = authenticatedId;
        }
    }
}
