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

        public void Add(Book book)
        {
            bookData.Add(book);
        }

        public bool Remove(Book book)
        {
            return bookData.Remove(book);
        }

        public List<Book> Search(string value)
        {
            return bookData.Search(value);
        }
    }
}
