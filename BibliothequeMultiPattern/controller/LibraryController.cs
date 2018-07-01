using BibliothequeMultiPattern.book.data;
using BibliothequeMultiPattern.events.handlers;
using BibliothequeMultiPattern.model;
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
using System;
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
            EventDispatcher eventDispatcher = new EventDispatcher();
            ISessionManager sessionManager = new UniqueSessionManagerImpl(eventDispatcher);

            userService = new UserServiceImpl(userData, authenticateData, new UserDtoAdapter(), sessionManager);
            bookService = new BookServiceImpl(bookData, eventDispatcher); 
        }

        /** Gestion des Utilisateurs **/

        public bool AddUser(UserDto userdto, string password) {
            return userService.Add(userdto, password);
        }

        public bool RemoveUser(string login)
        {
            return userService.Remove(login);
        }
        
        public UserDto ConnectUser(string login, string motDePasse)
        {
            return userService.Connect(login, motDePasse);
        }
       
        public bool LogOut(string token)
        {
            return userService.DisConnect(token);
        }

        /** Gestion des Livres **/
        public bool AddBook(Book book)
        {
            return bookService.Add(book);
        }

        public bool RemoveBook(string id)
        {
            return bookService.Remove(id);
        }

        public Book GetByIdBook(string id)
        {
            return bookService.GetById(id);
        }

        public List<Book> SearchBook(string value)
        {
            return bookService.Search(value);
        }

        /*public bool UpdateBook(Book book)
        {
            return bookService.Update(book);
        }*/

        public bool NextStepForBook(string bookId, Role role) {
            return bookService.NextStep(bookId, role);
         }

        /** Notifications **/
        public List<Event> GetEvents(string token)
        {
            return userService.GetEvents(token);
        }
    }
}
