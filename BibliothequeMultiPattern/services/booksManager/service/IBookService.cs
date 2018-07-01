using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.services.books.service
{
    public interface IBookService
    {
        bool Add(Book book);
        bool Remove(string id);
        bool Update(Book book);
        bool NextStep(string bookId, string role);
        List<Book> Search( string value);
        Book GetById(string bookId);
    }
}
