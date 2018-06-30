using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.services.users.service.dto
{
    public class UserDto
    {
        public string Login { get; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Role { get;}
        public string Token { get; }


        public UserDto(string login, string name, string firstName, string role, string token)
        {
            Login = login;
            Name = name;
            FirstName = firstName;
            Role = role;
            Token = token;
        }
    }
}
