using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliothequeMultiPattern.model;

namespace BibliothequeMultiPattern.persistences.users.inMemory
{
    public class UserInMemoryImpl : IUserData
    {
        List<UserInMemoryDao> datas;
        UserInMemoryAdapter adapter;

        public UserInMemoryImpl(UserInMemoryAdapter adapter)
        {
            this.adapter = adapter;
            datas = new List<UserInMemoryDao>();
        }

        public bool Add(User user)
        {
            if (null != user
                && null != user.id
                && null != user.id.id
                && !user.id.id.Equals("")
                && null != user.Name
                && !user.Name.Equals("")
                && null != user.FirstName
                && !user.FirstName.Equals("")
                && null != user.authenticatedId
                && null != user.authenticatedId.id
                && !user.authenticatedId.id.Equals("")
                && IsIdAvailable(user.id.id)
                )
            {
                datas.Add(adapter.ModelToDao(user));
                return true;
            }
            return false;
        }

        public User GetByAuthenticationId(string authenticationId)
        {
            if (datas.Count > 0)
            {
                foreach(var user in datas)
                {
                    if (user.authenticatedId.Equals(authenticationId))
                    {
                        return adapter.DaotoModel(user);
                    }
                }
                return null;
            }
            return null;
        }

        public User GetByUserId(string userId)
        {
            if (datas.Count > 0)
            {
                foreach (var user in datas)
                {
                    if (user.id.Equals(userId))
                    {
                        return adapter.DaotoModel(user);
                    }
                }
                return null;
            }
            return null;
        }

        public bool Remove(string userId)
        {
            if (datas.Count > 0)
            {
                foreach (var user in datas)
                {
                    if (user.id.Equals(userId))
                    {
                        return datas.Remove(user);
                    }
                }
                return false;
            }
            return false;
        }

        public bool IsIdAvailable(String id)
        {
            bool result = true;

            foreach (var entry in datas)
            {
                if (entry.id.Equals(id))
                {
                    result = false;
                }
            }
            return result;
        }

    }
}
