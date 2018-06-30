using BibliothequeMultiPattern.services.authenticator.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.services.authenticator.data
{
    public interface IAuthenticatorData
    {
        bool Add(Authenticate authenticate, string password);
        Authenticate GetByLogin(string login);
        Authenticate GetByAuthenticateId(string authenticateId);
        bool Remove(string login);
        bool IsIdAvailable(string id);
        List<Authenticate> GetAllByRole(string role);
        string GetPassword(string login);
    }
}
