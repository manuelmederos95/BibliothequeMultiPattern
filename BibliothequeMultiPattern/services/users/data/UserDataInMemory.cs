using System;
using System.Collections.Generic;

public class UserDataInMemory:IUserData
{
    Dictionary<string, IUser> Users;

    public UserDataInMemory()
	{
        Users = new Dictionary<string, IUser>();
        Users.Add("root", new Librarian("NAME", "FIRSTNAME", "root", "azerty"));
        Users.Add("student1", new Student("ST NAME", "ST FIRSTNAME", "student1", "mdp1"));
	}

    public bool Add(IUser user)
    {
        if (CheckIsComplete(user) && !Users.ContainsKey(user.Login))
        {
            Users.Add(user.Login, user);
            return true;
        } 
        return false;
    }

    public IUser Connect(string login, string motDePasse)
    {
        IUser user;
        if (Users.Count > 0)
        {
            Users.TryGetValue(login, out user);
              if (null != user && user.MotDePasse.Equals(motDePasse))
            {
                return user;
            }
        }
               return null;
    }

    public bool Remove(string login)
    {
        if (Users.Count>0 && Users.ContainsKey(login))
        {
            return Users.Remove(login);
        }
        return false;
    }

    private bool CheckIsComplete(IUser user)
    {
        if (null != user.FirstName && !"".Equals(user.FirstName.Trim())
            && null != user.Name && !"".Equals(user.Name.Trim())
            && null != user.Login && !"".Equals(user.Login.Trim())
            && null != user.MotDePasse && !"".Equals(user.MotDePasse.Trim())
            )
        {
            return true;

        }
        return false;
    }

    public int GetCount()
    {
        return Users.Count;
    }

    public void Clear()
    {
        Users.Clear();
    }
}
