using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.services.users
{
    interface IUserService
    {
        IUser Connect(string login, string motDePasse);

        bool Add(IUser user);

        bool Remove(string login);
    }
}
