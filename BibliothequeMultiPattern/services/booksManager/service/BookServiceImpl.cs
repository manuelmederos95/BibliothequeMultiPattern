using BibliothequeMultiPattern.book.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.services.books.service
{
    class BookServiceImpl : IBookService
    {
        IBookData bookData;

        public BookServiceImpl(IBookData bookData)
        {
            this.bookData = bookData;
        }

        public bool Add(Book book)
        {
            if (null != book.Id
                && !"".Equals(book.Id)
                && null != book.Title
                && !"".Equals(book.Title))
            {
                return bookData.Add(book);
            }
            return false;
        }

        public bool Remove(string id)
        {
            return bookData.Remove(id);
        }

        public List<Book> Search(string value)
        {
            return bookData.Search(value);
        }
    }
}
