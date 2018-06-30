using BibliothequeMultiPattern.events.handlers;
using BibliothequeMultiPattern.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.services.sessionManager
{
    public interface ISessionManager
    {
        string Add(string userId);
        bool Delete(string userId);
        List<Event> GetEvents(string token);
    }
}
