using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.book.data
{
    public interface IBookData
    {
        void Add(Book book);
        bool Remove(Book book);
        void Update(Book book);
        List<Book> Search(string value);
    }
}
