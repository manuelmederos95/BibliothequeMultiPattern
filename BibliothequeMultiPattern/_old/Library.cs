using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern
{
    class Library
    {   

        private List<Book> Books;
        private static Library instance = null;

        private Library()
        {
            
        }

        public static Library Instace
        {
            get
            {
                if(instance == null)
                {
                    instance = new Library();
                }
                return instance;
            }
        }

        public void addBook(Book book)
        {
            Books.Add(book);
        }

        public Book getBookByTitle(String title)
        {
            foreach (var item in Books)
            {
                if (item.Title.Equals(title)) {
                    Books.Remove(item);
                    return item;
                }
            }

            return null;
        }
    }
}
