using BibliothequeMultiPattern.services.users;
using BibliothequeMultiPattern.services.users.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern
{
    public class LibraryController
    {

        /** Gestion des Utilisateurs **/
        IUserService userService = new UserService();

        public bool Add(IUser user) {
            return userService.Add(user);
        }

        public bool Remove(string login)
        {
            return userService.Remove(login);
        }

        public IUser Connect(string login, string motDePasse)
        {
            return userService.Connect(login, motDePasse);
        }


        //s'authentifier

        //creer un compte

        //supprimer un compte



    }
}
