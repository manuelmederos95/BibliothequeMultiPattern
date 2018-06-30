using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliothequeMultiPattern.persistences.authenticator.adapter;
using BibliothequeMultiPattern.services.authenticator.model;

namespace BibliothequeMultiPattern.persistences.authenticator.inMemory
{
    public class AuthenticateInMemoryAdapter
    {
        internal AuthenticateInMemoryDao ModelToDao(Authenticate authenticate, string password)
        {
            return new AuthenticateInMemoryDao(authenticate.authenticateId.id, authenticate.login, password, authenticate.role);
        }

        internal Authenticate DaoToModel(AuthenticateInMemoryDao authenticateInMemoryDao)
        {
            return new Authenticate(new AuthenticateId(authenticateInMemoryDao.id), authenticateInMemoryDao.login, authenticateInMemoryDao.role);
        }
    }
}
