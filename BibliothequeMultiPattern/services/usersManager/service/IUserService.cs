using BibliothequeMultiPattern.events.handlers;
using BibliothequeMultiPattern.services.users.service.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.services.users
{
    public interface IUserService
    {
        bool Add(UserDto userDto, string motDePasse);

        UserDto GetByUserId(string userId);

        List<UserDto> GetByUsersByRole(string role);

        bool Remove(string userId);

        UserDto Connect(string login, string motDePasse);

        bool DisConnect(string userId);

        List<Event> GetEvents(string token);

    }
}
