﻿using System;
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