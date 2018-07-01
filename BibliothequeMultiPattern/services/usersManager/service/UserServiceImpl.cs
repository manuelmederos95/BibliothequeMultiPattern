using BibliothequeMultiPattern.events.handlers;
using BibliothequeMultiPattern.model;
using BibliothequeMultiPattern.persistences.users;
using BibliothequeMultiPattern.services.authenticator.data;
using BibliothequeMultiPattern.services.authenticator.model;
using BibliothequeMultiPattern.services.idGenerator;
using BibliothequeMultiPattern.services.idsGenerator;
using BibliothequeMultiPattern.services.sessionManager;
using BibliothequeMultiPattern.services.users.service.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.services.users.service
{
    class UserServiceImpl : IUserService
    {
        IUserData userData;
        IAuthenticatorData authenticateData;
        ISessionManager sessionManager;
        UserIdGenerator userIdGenerator;
        AuthenticateIdGenerator authenticateIdGenerator;
        UserDtoAdapter userDtoAdapter;

        public UserServiceImpl(
            IUserData userData, 
            IAuthenticatorData authenticateData, 
            UserDtoAdapter userDtoAdapter, 
            ISessionManager sessionManager)
        {
            this.userData = userData;
            this.userDtoAdapter = userDtoAdapter;
            this.authenticateData = authenticateData;
            this.sessionManager = sessionManager;

            this.userIdGenerator = new UserIdGenerator(userData);
            this.authenticateIdGenerator = new AuthenticateIdGenerator(authenticateData);
        }

        public bool Add(UserDto userDto, string motDePasse)
        {
            if(null != userDto
                && null != motDePasse
                && !"".Equals(motDePasse)){
                /* On crée les identifiants */
                AuthenticateId authenticateId = authenticateIdGenerator.GenerateId();
                bool result = authenticateData.Add(new Authenticate(authenticateId, userDto.Login, userDto.Role), motDePasse);

                if (!result) { return result; }

                /* On crée l'utilisateur */
                UserId userId = userIdGenerator.GenerateId();
                return userData.Add(userDtoAdapter.DtoToModel(userDto, userId, authenticateId));
            }
            return false;
        }

        public bool Remove(string login)
        {
            if(null != login)
            {
                Authenticate authenticate = authenticateData.GetByLogin(login);
                User user = userData.GetByAuthenticationId(authenticate.authenticateId.id);

                if (null != authenticate && null != user)
                {
                    /* On supprime l'utilisateur */
                    bool result = userData.Remove(user.id.id);

                    if (!result) { return result; }

                    /* On supprime ses identifiants */
                    return authenticateData.Remove(login);                    
                }
            }
            return false;
        }

        public UserDto GetByUserId(string userId)
        {
            if(null == userId || userId.Equals("")) { return null; }
            User user = userData.GetByUserId(userId);
            if (null == user) { return null; }
            Authenticate authenticate = authenticateData.GetByAuthenticateId(user.authenticatedId.id);
            if (null == authenticate) { return null; }
            return userDtoAdapter.ModelToDto(user, authenticate,null);
        }

        public List<UserDto> GetByUsersByRole(string role)
        {
            List<Authenticate> authenticates = authenticateData.GetAllByRole(role);
            List<UserDto> userDtos = new List<UserDto>();

            foreach(var authenticate in authenticates)
            {
                User user = userData.GetByAuthenticationId(authenticate.authenticateId.id);
                userDtos.Add(userDtoAdapter.ModelToDto(user, authenticate, null));
            }
            return userDtos;
        }

        UserDto IUserService.Connect(string login, string motDePasse)
        {
            if (null != motDePasse
                && !"".Equals(motDePasse)
                && null != login
                && !"".Equals(login)
                && motDePasse.Equals(authenticateData.GetPassword(login))){
                Authenticate authenticate = authenticateData.GetByLogin(login);
                User user = userData.GetByAuthenticationId(authenticate.authenticateId.id);

                string token = sessionManager.Add(user.id.id);

                return userDtoAdapter.ModelToDto(user, authenticate, token);
            };
            return null;
        }

        public bool DisConnect(string token)
        {
            return sessionManager.Delete(token);
        }

        public List<Event> GetEvents(string token)
        {
            return sessionManager.GetEvents(token);
        }
    }
}
