using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.services.books.service
{
    interface IBookService
    {
        void Add(Book book);
        bool Remove(Book book);
        List<Book> Search(string value);
    }
}
