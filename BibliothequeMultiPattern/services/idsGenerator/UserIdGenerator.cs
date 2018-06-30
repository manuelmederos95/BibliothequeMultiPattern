using BibliothequeMultiPattern.model;
using BibliothequeMultiPattern.persistences.users;
using BibliothequeMultiPattern.services.authenticator.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.services.idGenerator
{
    public class UserIdGenerator
    {
        IUserData userData;

        public UserIdGenerator(IUserData userData)
        {
            this.userData = userData;
        }

        public UserId GenerateId()
        {
            string userID = Util.RandomId();
            while (!userData.IsIdAvailable(userID))
            {
                userID = Util.RandomId();
            }
            return new UserId(userID);
        }     
    }
}
