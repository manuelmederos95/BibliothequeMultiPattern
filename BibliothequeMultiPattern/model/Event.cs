using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.events.handlers
{
    public class Event
    {
        string Type { get;}
        string Value { get;}

        public Event(string type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
