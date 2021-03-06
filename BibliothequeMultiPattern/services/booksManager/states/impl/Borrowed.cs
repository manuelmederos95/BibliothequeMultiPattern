﻿using BibliothequeMultiPattern.events.handlers;
using BibliothequeMultiPattern.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.state.impl
{
    class Borrowed : IState
    {
        public bool authorizedUser(Role role)
        {
            return role.Equals(Role.student) || role.Equals(Role.librarian);
        }

        public string getInfo()
        {
            return "Cet ouvrage a été emprunté.";
        }

        public string getName()
        {
            return "Emprunté";
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
