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
        public string Id { get; }
        public string Title { get; }
        public IState State { get;}

        protected Book(string id, string titre)
        {
            this.Id = id;
            this.Title = titre;
            State = new Stocked();
        }

        public abstract float getRefoundPrice();
    }
}
