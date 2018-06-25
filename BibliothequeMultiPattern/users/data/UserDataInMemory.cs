using System;
using System.Collections.Generic;

public class UserDataInMemory:IUserData
{
    Dictionary<string, IUser> Users;
    UserDataInMemory userDataInMemory;

    private UserDataInMemory()
	{
        Users = new Dictionary<string, IUser>();
	}

    public bool Add(IUser user)
    {
        if (Users.ContainsKey(user.Login))
        {
            return false;
        } else
        {
            Users.Add(user.Login, user);
            return true;
        }
    }

    public IUser Connect(string login, string motDePasse)
    {
        IUser user;
        Users.TryGetValue(login, out user);
        if (null != user && user.MotDePasse.Equals(motDePasse))
        {
                return user;
        }
        return null;
    }

    public void Remove(IUser user)
    {
        if (Users.ContainsKey(user.Login))
        {
            Users.Remove(user.Login);
        }
    }

    public UserDataInMemory getInstance()
    {
        if(null == userDataInMemory)
        {
            userDataInMemory = new UserDataInMemory();
        }
        return userDataInMemory;
    }
}
