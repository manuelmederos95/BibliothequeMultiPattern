using BibliothequeMultiPattern.events.handlers;
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
        public IState State { get; set; }
        public EventDispatcher eventDispatcher { get; set; }
        public string lastStepUserId { get; set; }

        protected Book(string id, string titre)
        {
            this.Id = id;
            this.Title = titre;
            State = new Stocked();
        }

        public void nextStep()
        {
        this.State = State.nextStep();
        eventDispatcher.NotifyAll(new Event("[Book : " + Title + "]", System.DateTime.Now.ToShortDateString() + " - " +State.getInfo()));
        }

        public abstract float getRefoundPrice();
    }
}
