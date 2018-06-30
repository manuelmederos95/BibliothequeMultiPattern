using BibliothequeMultiPattern.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.persistences.users
{
    public interface IUserData
    {
        bool Add(User user);
        User GetByUserId(string userId);
        User GetByAuthenticationId(string authenticationId);
        bool Remove(string userId);
        bool IsIdAvailable(String id);
    }
}
