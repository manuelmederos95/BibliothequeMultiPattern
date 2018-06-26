using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.events.handlers
{
    class LibrarianEventHandler
    {
        List<ILibrarianEvent> subscribers;

        public LibrarianEventHandler()
        {
            this.subscribers = new List<ILibrarianEvent>();
        }
    }
}
