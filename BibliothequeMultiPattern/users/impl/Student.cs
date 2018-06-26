using System;

public class Student:IUser
{
	public Student(){}

    public Student(string name, string firstName, string login, string motDePasse)
    {
        Name = name;
        FirstName = firstName;
        Login = login;
        MotDePasse = motDePasse;
    }

    public string Name { get; set; }
    public string FirstName { get; set; }
    public string Login { get; set; }
    public string MotDePasse { get; set; }

    public string GetRole()
    {
        return "Student";
    }
}
