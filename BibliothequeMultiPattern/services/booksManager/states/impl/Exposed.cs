using BibliothequeMultiPattern.events.handlers;
using BibliothequeMultiPattern.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.state.impl
{
    class Exposed : IState
    {
        public bool authorizedUser(Role role)
        {
            return role.Equals(Role.student);
        }

        public string getInfo()
        {
            return "Cet ouvrage est présent en rayon.";
        }

        public string getName()
        {
            return "En rayon";
        }

        public bool isAvailable()
        {
            return true;
        }

        public IState nextStep()
        {
            return new Borrowed();
        }
    }
}
