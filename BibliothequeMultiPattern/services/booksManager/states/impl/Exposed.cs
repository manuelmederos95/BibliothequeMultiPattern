using BibliothequeMultiPattern.events.handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.state.impl
{
    class Exposed : IState
    {
        public bool authorizedUser(string role)
        {
            return role.Equals("student");
        }

        public string getInfo()
        {
            return "Cet ouvrage est présent en rayon.";
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
