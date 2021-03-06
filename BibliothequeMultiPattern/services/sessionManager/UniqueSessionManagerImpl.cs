﻿using BibliothequeMultiPattern.events.handlers;
using BibliothequeMultiPattern.model;
using BibliothequeMultiPattern.services.sessionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.services
{
    public class UniqueSessionManagerImpl : ISessionManager
    {
        private Dictionary<string,UserSession> connectedUser = new Dictionary<string, UserSession>();
        EventDispatcher eventDispatcher;

        public UniqueSessionManagerImpl(EventDispatcher eventDispatcher)
        {
            this.eventDispatcher = eventDispatcher;
        }

        public string Add(string userId)
        {
            if(null == userId) { return null; }
            Random random = new Random();
            string token = random.Next().ToString();

            UserSession userSession = new UserSession(userId);
            eventDispatcher.Register(userSession);
            connectedUser.Add(token, userSession);
            return token;
        }

        public bool Delete(string token)
        {
            if (null == token
                || token.Equals("")
                || !connectedUser.ContainsKey(token)) { return false; }

            connectedUser = new Dictionary<string, UserSession>();
            return true;
        }

        public List<Event> GetEvents(string token)
        {
           UserSession userSession;
           connectedUser.TryGetValue(token, out userSession);
            if(null == userSession) { return new List<Event>(); }

            List<Event> toReturn = userSession.librarianEvents;
            userSession.librarianEvents = new List<Event>();
            return toReturn;
        }
    }
}
