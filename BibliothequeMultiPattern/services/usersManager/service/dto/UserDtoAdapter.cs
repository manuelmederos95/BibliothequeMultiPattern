using System;
using BibliothequeMultiPattern.model;
using BibliothequeMultiPattern.services.authenticator.model;
using BibliothequeMultiPattern.services.users.service.dto;

namespace BibliothequeMultiPattern.services.users.service
{
    internal class UserDtoAdapter
    {

        internal User DtoToModel(UserDto userDto, UserId userId, AuthenticateId authenticateId)
        {
           return new User(userId, userDto.Name, userDto.FirstName, authenticateId);
        }

        internal UserDto ModelToDto(User user, Authenticate authenticate, string token)
        {
            return new UserDto(authenticate.login, user.Name, user.FirstName, authenticate.role, token);
        }
    }
}