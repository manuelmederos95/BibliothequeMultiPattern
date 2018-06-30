using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.persistences.users.inMemory
{
    public class UserInMemoryDao
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string authenticatedId { get; set; }

        public UserInMemoryDao(string id, string name, string firstName, string authenticatedId)
        {
            this.id = id;
            Name = name;
            FirstName = firstName;
            this.authenticatedId = authenticatedId;
        }
    }
}
