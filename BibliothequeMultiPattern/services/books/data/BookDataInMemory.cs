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
        private static BookDataInMemory bookDataInMemory { get; set; }
        private List<Book> Books;

        private BookDataInMemory()
        {
            Books = new List<Book>();
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

        public static BookDataInMemory GetInstance()
        {
            if (null == bookDataInMemory)
            {
                bookDataInMemory = new BookDataInMemory();
            }
            return bookDataInMemory;
        }

        private bool CheckIsComplete(Book book)
        {
            if (null != book.Title.Trim() 
                && !"".Equals(book.Title.Trim())
                && null != (book.State)
                && null != book.Id)
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
