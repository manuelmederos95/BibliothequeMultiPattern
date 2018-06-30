using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.services
{
    public static class Util
    {
        public static String RandomId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
    }
}
