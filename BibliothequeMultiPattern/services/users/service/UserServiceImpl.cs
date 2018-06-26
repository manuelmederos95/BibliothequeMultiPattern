using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.services.users.service
{
    class UserServiceImpl : IUserService
    {
        IUserData userData;

        public UserServiceImpl(IUserData userData)
        {
            this.userData = userData;
        }

        public bool Add(IUser user)
        {
            return userData.Add(user);
        }

        public IUser Connect(string login, string motDePasse)
        {
            return userData.Connect(login, motDePasse);
        }

        public bool Remove(string login)
        {
            return userData.Remove(login);
        }
    }
}
