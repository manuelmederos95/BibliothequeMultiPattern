using BibliothequeMultiPattern.services.authenticator.data;
using BibliothequeMultiPattern.services.authenticator.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.services.idsGenerator
{
    public class AuthenticateIdGenerator
    {
        IAuthenticatorData authenticateData;

        public AuthenticateIdGenerator(IAuthenticatorData authenticateData)
        {
            this.authenticateData = authenticateData;
        }

        public AuthenticateId GenerateId()
        {
            string authenticateID = Util.RandomId();
            while (!authenticateData.IsIdAvailable(authenticateID))
            {
                authenticateID = Util.RandomId();
            }
            return new AuthenticateId(authenticateID);
        }
    }
}
