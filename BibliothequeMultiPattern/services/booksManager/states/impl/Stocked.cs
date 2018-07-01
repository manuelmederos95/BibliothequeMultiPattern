using BibliothequeMultiPattern.events.handlers;
using BibliothequeMultiPattern.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.state.impl
{
    class Stocked : IState
    {
        public bool authorizedUser(Role role)
        {
            return role.Equals(Role.librarian);
        }

        public string getInfo()
        {
            return "Cet ouvrage est archivé.";
        }

        public bool isAvailable()
        {
            return false;
        }

        public IState nextStep()
        {
            return new Exposed();
        }
    }
}
