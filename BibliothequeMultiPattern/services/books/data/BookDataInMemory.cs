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
            Book book1 = new BookBasic(1, "Harry Potter 1");
            Book book2 = new BookWithDvd(2, "TOIC Preparation", 3);
            Book book3 = new BookBasic(3, "Harry Potter 2");
            Books.Add(book1);
            Books.Add(book2);
            Books.Add(book3);
        }
  
        public void Add(Book book)
        {
            if (CheckIsComplete(book))
            {
                Books.Add(book);
            }
        }

        public bool Remove(Book book)
        {
            return Books.Remove(book);
        }

        public List<Book> Search(string value)
        {
            List<Book> books = new List<Book>();
      
                Regex RegexToCheck = new Regex(value);
                foreach (var Book in Books)
                {
                    if (RegexToCheck.IsMatch(Book.Title))
                    {
                        books.Add(Book);
                    }
                }
                
            
            return books;
        }

        public void Update(Book book)
        {
            Remove(book);
            Add(book);
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
     }
}
