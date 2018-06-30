using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.events.handlers
{
    public interface IEventListener
    {
        void OnEvent(Event librarianEvent);
    }
}
