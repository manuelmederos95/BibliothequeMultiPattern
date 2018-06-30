using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.services.authenticator.model
{
    public class AuthenticateId
    {
        public string id { get; }

        public AuthenticateId(string id)
        {
            this.id = id;
        }
    }
}
