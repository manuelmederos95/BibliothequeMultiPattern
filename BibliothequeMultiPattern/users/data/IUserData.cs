using System;

public interface IUserData
{
     IUser Connect(string login, string motDePasse);

     bool Add(IUser user);

     void Remove(IUser user);
}
