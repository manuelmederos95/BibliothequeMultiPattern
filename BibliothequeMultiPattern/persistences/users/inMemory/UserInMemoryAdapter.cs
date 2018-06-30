using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliothequeMultiPattern.model;
using BibliothequeMultiPattern.services.authenticator.model;

namespace BibliothequeMultiPattern.persistences.users.inMemory
{
    public class UserInMemoryAdapter
    {
        internal UserInMemoryDao ModelToDao(User user)
        {
            return new UserInMemoryDao(user.id.id, user.Name, user.FirstName, user.authenticatedId.id);
        }

        internal User DaotoModel(UserInMemoryDao user)
        {
            return new User(new UserId(user.id), user.Name, user.FirstName, new AuthenticateId(user.authenticatedId));
        }
    }
}
