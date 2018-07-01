using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.book.data
{
     public class BookDataInMemory : IBookData
    {
        private List<Book> Books;

        public BookDataInMemory()
        {
            Books = new List<Book>();
        }
  
        public bool Add(Book book)
        {
            if (CheckIsComplete(book))
            {
                 Books.Add(book);
                return true;
            }
            return false;
        }

        public bool Remove(string id)
        {
            foreach(var book in Books)
            {
                if (book.Id.Equals(id))
                {
                    Books.Remove(book);
                    return true;
                }
            }
            return false;
        }

        public List<Book> Search(string value)
        {
            List<Book> books = new List<Book>();
      
                Regex RegexToCheck = new Regex(value.ToUpper());
                foreach (var Book in Books)
                {
                    if (RegexToCheck.IsMatch(Book.Title.ToUpper()))
                    {
                        books.Add(Book);
                    }
                }
                
            
            return books;
        }

        public bool Update(Book book)
        {
            Remove(book.Id);
            return Add(book);
        }

        private bool CheckIsComplete(Book book)
        {
            if (null != book.Title.Trim() 
                && !"".Equals(book.Title.Trim())
                && null != (book.State))
            {
                return true;
            }
            return false;
        }

        public void Clear()
        {
            Books.Clear();
        }

        public Book GetById(string id)
        {
            if (null != id)
            {
                foreach (var Book in Books)
                {
                    if (Book.Id.Equals(id))
                    {
                        return Book;
                    }
                }
            }
           
            return null;
        }
    }
}
