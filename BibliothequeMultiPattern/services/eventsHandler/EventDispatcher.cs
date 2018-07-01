using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.events.handlers
{
    public class EventDispatcher
    {
        List<IEventListener> subscribers;
        List<Event> waitingEvents;

        public EventDispatcher()
        {
            this.subscribers = new List<IEventListener>();
            this.waitingEvents = new List<Event>();
        }

        public void Register(IEventListener librarianListener)
        {
            Console.WriteLine("DANS Register");

            if (subscribers.Count() == 0)
            {
                foreach(var LibrarianEvent in waitingEvents)
                {
                    librarianListener.OnEvent(LibrarianEvent);
                }
                waitingEvents = new List<Event>();
            }

            subscribers.Add(librarianListener);
        }

        public void NotifyAll(Event librarianEvent)
        {
            if (subscribers.Count() == 0)
            {
                Console.WriteLine("DANS NotifyAll : 0");

                waitingEvents.Add(librarianEvent);
            } else
            {
                Console.WriteLine("DANS NotifyAll : all");

                foreach (var ILibrarianEvent in subscribers)
                {
                    ILibrarianEvent.OnEvent(librarianEvent);
                }
            }
        }

        public void ClearWaitingList()
        {
            this.waitingEvents = new List<Event>();
        }
    }
}
