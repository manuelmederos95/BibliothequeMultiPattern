using BibliothequeMultiPattern.events.handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.model
{
    public class UserSession : IEventListener
    {
        public string userId;
        public List<Event> librarianEvents  { get; }

        public UserSession(string userId)
        {
            this.userId = userId;
            librarianEvents = new List<Event>();
        }

        public void OnEvent(Event librarianEvent)
        {
            librarianEvents.Add(librarianEvent);
        }
    }
}
