using BibliothequeMultiPattern.state;
using BibliothequeMultiPattern.state.impl;
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
        public String Title { get; set; }
        public IState State { get;}

        protected Book(int id, String titre)
        {
            this.Id = id;
            this.Title = titre;
            State = new Stocked();
        }

        public abstract float getRefoundPrice();
    }
}
