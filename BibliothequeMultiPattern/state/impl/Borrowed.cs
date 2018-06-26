using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.state.impl
{
    class Borrowed : IState
    {
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
