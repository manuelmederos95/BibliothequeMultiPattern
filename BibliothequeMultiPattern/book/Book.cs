using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern
{
    //abstract class for book
    public abstract class Book
    {
        public int Id { get; set; }
        private String Titre { get; set; }

        protected Book(int id, String titre)
        {
            this.Id = id;
            this.Titre = titre;
        }

        public abstract float getRefoundPrice();
    }
}
