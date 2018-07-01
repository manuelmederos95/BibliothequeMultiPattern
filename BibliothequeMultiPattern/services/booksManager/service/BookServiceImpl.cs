using BibliothequeMultiPattern.book.data;
using BibliothequeMultiPattern.events.handlers;
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
        EventDispatcher eventDispatcher;

        public BookServiceImpl(IBookData bookData, EventDispatcher eventDispatcher)
        {
            this.bookData = bookData;
            this.eventDispatcher = eventDispatcher;
        }

        public bool Add(Book book)
        {
            if (null != book.Id
                && !"".Equals(book.Id)
                && null != book.Title
                && !"".Equals(book.Title))
            {
                book.eventDispatcher = eventDispatcher;
                return bookData.Add(book);
            }
            return false;
        }

        public bool Remove(string id)
        {
            return bookData.Remove(id);
        }

        public bool Update(Book book)
        {
            if(null == book) { return false; }
            bool removed = Remove(book.Id);
            if (!removed) { return false; }
            return Add(book);
        }

        public List<Book> Search(string value)
        {
            return bookData.Search(value);
        }

        public bool NextStep(string bookId, string role)
        {
            if(null != bookId
                && !"".Equals(bookId)
                && null != role
                && !"".Equals(role))
            {
                Book book = bookData.GetById(bookId);
                if (book.State.authorizedUser(role))
                {
                    book.nextStep();
                    return bookData.Update(book);
                }
            }
            return false;
        }

        public Book GetById(string bookId)
        {
            if(null != bookId
                && !"".Equals(bookId))
            {
                return bookData.GetById(bookId);
            }
            return null;        
                }
    }
}
