using BibliothequeMultiPattern.book.data;
using BibliothequeMultiPattern.services.books.service;
using BibliothequeMultiPattern.services.users;
using BibliothequeMultiPattern.services.users.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern
{
    public class LibraryController
    {
        IUserData userData;
        IBookData bookData;
        IUserService userService;
        IBookService bookService;

        public LibraryController()
        {
            userData = new UserDataInMemory();
            bookData = new BookDataInMemory();
            userService = new UserServiceImpl(userData);
            bookService = new BookServiceImpl(bookData);
        }

        /** Gestion des Utilisateurs **/
        public bool Add(IUser user) {
            return userService.Add(user);
        }

        public bool Remove(string login)
        {
            return userService.Remove(login);
        }

        public IUser Connect(string login, string motDePasse)
        {
            return userService.Connect(login, motDePasse);
        }

        /** Gestion des Livres **/
        public void AddBook(Book book)
        {
            bookService.Add(book);
        }

        public bool RemoveBook(Book book)
        {
            return bookService.Remove(book);
        }

        public List<Book> SearchBook(string value)
        {
            return bookService.Search(value);
        }
    }
}
