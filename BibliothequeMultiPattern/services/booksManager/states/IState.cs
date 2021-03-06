﻿using BibliothequeMultiPattern.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.state
{
    public interface IState
    {
      string getInfo();
      bool isAvailable();
      bool authorizedUser(Role role);
      IState nextStep();
        string getName();
    }
}
