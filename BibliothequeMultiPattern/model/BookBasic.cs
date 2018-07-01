using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.book
{
    public class BookBasic : Book
    {

        public BookBasic(string id, string titre):base(id,titre)
        {

        }
        public override float getRefoundPrice()
        {
            float BasicPrice = 50;
            return BasicPrice;
        }

    }
}
