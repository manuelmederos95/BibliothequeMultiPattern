using System;

public interface IUser
{
    string Name { get; set; }
    string FirstName { get; set; }
    string Login { get; set; }
    string MotDePasse { get; set; }
    string GetRole();
}
