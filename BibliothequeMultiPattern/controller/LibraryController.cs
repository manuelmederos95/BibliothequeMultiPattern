using BibliothequeMultiPattern.book.data;
using BibliothequeMultiPattern.events.handlers;
using BibliothequeMultiPattern.persistences.authenticator.inMemory;
using BibliothequeMultiPattern.persistences.users;
using BibliothequeMultiPattern.persistences.users.inMemory;
using BibliothequeMultiPattern.services;
using BibliothequeMultiPattern.services.authenticator.data;
using BibliothequeMultiPattern.services.books.service;
using BibliothequeMultiPattern.services.sessionManager;
using BibliothequeMultiPattern.services.users;
using BibliothequeMultiPattern.services.users.service;
using BibliothequeMultiPattern.services.users.service.dto;
using System.Collections.Generic;

namespace BibliothequeMultiPattern
{
    public class LibraryController 
    {
        IUserService userService;
        IBookService bookService;

        public LibraryController(IUserService userService, IBookService bookService)
        {
            this.userService = userService;
            this.bookService = bookService;
        }

        public LibraryController()
        {
            IUserData userData = new UserInMemoryImpl(new UserInMemoryAdapter());
            IAuthenticatorData authenticateData = new AuthenticateInMemoryImpl(new AuthenticateInMemoryAdapter());
            IBookData bookData = new BookDataInMemory();

            userService = new UserServiceImpl(userData, authenticateData, new UserDtoAdapter(), new UniqueSessionManagerImpl(new EventDispatcher()));
            bookService = new BookServiceImpl(bookData); 
        }

        /** Gestion des Utilisateurs **/

        public bool Add(UserDto userdto, string password) {
            return userService.Add(userdto, password);
        }

        public bool Remove(string login)
        {
            return userService.Remove(login);
        }
        
        public UserDto Connect(string login, string motDePasse)
        {
            return userService.Connect(login, motDePasse);
        }
       
        public bool LogOut(string token)
        {
            return userService.DisConnect(token);
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

        /** Notifications **/
       public List<Event> GetEvents(string token)
        {
            return userService.GetEvents(token);
        }
    }
}
