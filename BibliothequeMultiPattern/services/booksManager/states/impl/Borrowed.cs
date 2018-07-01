using BibliothequeMultiPattern.events.handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.state.impl
{
    class Borrowed : IState
    {
        public bool authorizedUser(string role)
        {
            return role.Equals("student")|| role.Equals("librarian");
        }

        public string getInfo()
        {
            return "Cet ouvrage a été emprunté.";
        }

        public bool isAvailable()
        {
            return false;
        }

        public IState nextStep()
        {
            return new Returned();
        }
    }
}
