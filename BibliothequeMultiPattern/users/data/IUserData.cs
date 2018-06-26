using System;

public interface IUserData
{
     IUser Connect(string login, string motDePasse);

     bool Add(IUser user);

     bool Remove(string login);
}
