using BibliothequeMultiPattern.events.handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.state.impl
{
    class Returned : IState
    {
        public bool authorizedUser(string role)
        {
            return role.Equals("librarian");
        }

        public string getInfo()
        {
            return "Cet ouvrage vient d'être rendu.";        
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
