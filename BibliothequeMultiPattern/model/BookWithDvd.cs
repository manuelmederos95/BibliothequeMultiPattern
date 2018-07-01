using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.book
{
    
    public class BookWithDvd : Book
    {
        private int NbDvd { get; set; }
        public BookWithDvd (string id, string titre, int nbDvd) : base(id, titre)
        {
            this.NbDvd = nbDvd;
        }
        public override float getRefoundPrice()
        {
            float BasicPrice = 50;
            float DvdPrice = 30;

            return BasicPrice + DvdPrice * NbDvd;
        }
    }
}
