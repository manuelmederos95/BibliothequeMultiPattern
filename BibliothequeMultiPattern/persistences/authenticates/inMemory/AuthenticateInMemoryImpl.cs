using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliothequeMultiPattern.persistences.authenticator.adapter;
using BibliothequeMultiPattern.persistences.authenticator.inMemory;
using BibliothequeMultiPattern.services.authenticator.model;

namespace BibliothequeMultiPattern.services.authenticator.data
{
    public class AuthenticateInMemoryImpl : IAuthenticatorData
    {
        Dictionary<string, AuthenticateInMemoryDao> datas;
        AuthenticateInMemoryAdapter adapter; 

        public AuthenticateInMemoryImpl(AuthenticateInMemoryAdapter authenticateInMemoryAdapter)
        {
            datas = new Dictionary<string, AuthenticateInMemoryDao>();
            this.adapter = authenticateInMemoryAdapter;
        }

        public bool Add(Authenticate authenticate, string password)
        {
            if(null != authenticate
                && null != authenticate.authenticateId
                && null != authenticate.authenticateId.id
                && !"".Equals(authenticate.authenticateId.id)
                && null != authenticate.login
                && !"".Equals(authenticate.login)
                && null != authenticate.role
                && !"".Equals(authenticate.role)
                && null != password
                && !"".Equals(password)
                && IsIdAvailable(authenticate.authenticateId.id)
                )
            {
                datas.Add(authenticate.login, adapter.ModelToDao(authenticate, password));
                return true;
            }
            return false;
        }

        public Authenticate GetByLogin(string login)
        {
            if (datas.Count > 0)
            {
                AuthenticateInMemoryDao authenticateInMemoryDao;
                datas.TryGetValue(login, out authenticateInMemoryDao);
                if (null != authenticateInMemoryDao)
                {
                    return adapter.DaoToModel(authenticateInMemoryDao);
                }
                return null;
            }
            return null;
        }

        public bool Remove(string login)
        {
            if (datas.Count() > 0 && datas.ContainsKey(login))
            {
                return datas.Remove(login);
            }

            return false;
        }

        public bool IsIdAvailable(String id)
        {
            bool result = true;

            foreach (KeyValuePair<string, AuthenticateInMemoryDao> entry in datas)
            {
                if (entry.Value.id.Equals(id))
                {
                    result = false;
                }
            }
            return result;
        }

        public Authenticate GetByAuthenticateId(string authenticateId)
        {
            foreach (KeyValuePair<string, AuthenticateInMemoryDao> entry in datas)
            {
                if (entry.Value.id.Equals(authenticateId))
                {
                    return adapter.DaoToModel(entry.Value);
                }
            }
            return null;
        }

        public List<Authenticate> GetAllByRole(string role)
        {
            List<Authenticate> results = new List<Authenticate>();
            foreach (KeyValuePair<string, AuthenticateInMemoryDao> entry in datas)
            {
                if (entry.Value.role.Equals(role))
                {
                    results.Add(adapter.DaoToModel(entry.Value));
                }
            }
            return results;
        }

        public string GetPassword(string login)
        {
            if (datas.Count > 0)
            {
                AuthenticateInMemoryDao authenticateInMemoryDao;
                datas.TryGetValue(login, out authenticateInMemoryDao);
                if (null != authenticateInMemoryDao)
                {
                    return authenticateInMemoryDao.password;
                }
                return null;
            }
            return null;
        }
    }
}
