using BibliothequeMultiPattern.events.handlers;
using BibliothequeMultiPattern.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.state.impl
{
    class Returned : IState
    {
        public bool authorizedUser(Role role)
        {
            return role.Equals(Role.librarian);
        }

        public string getInfo()
        {
            return "Cet ouvrage vient d'être rendu.";        
        }

        public string getName()
        {
            return "Temporairement indisponible";
        }

        public bool isAvailable()
        {
            return false;
        }

        public IState nextStep()
        {
            return new Stocked();
        }
    }
}
