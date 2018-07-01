using BibliothequeMultiPattern;
using BibliothequeMultiPattern.book;
using BibliothequeMultiPattern.events.handlers;
using BibliothequeMultiPattern.model;
using BibliothequeMultiPattern.services.users.service.dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPatternTest.controller
{
    [TestClass]
    public class LibraryControllerTest
    {
        LibraryController libraryController;

        private void init()
        {
            libraryController = new LibraryController();

            UserDto userDto0 = new UserDto("login0", "name0", "firstname0", Role.student, null);
            libraryController.AddUser(userDto0, "password0");

            UserDto userDto1 = new UserDto("login1", "name1", "firstname1", Role.student, null);
            libraryController.AddUser(userDto1, "password1");

            UserDto userDto2 = new UserDto("login2", "name2", "firstname2", Role.librarian, null);
            libraryController.AddUser(userDto1, "password2");

            UserDto userDto3 = new UserDto("login3", "name3", "firstname3", Role.librarian, null);
            libraryController.AddUser(userDto3, "password3");

            Book bookBasic = new BookBasic("AS0", "TitreAS0");
            Assert.IsTrue(libraryController.AddBook(bookBasic));

            Book bookBasic1 = new BookBasic("AS1", "TitreAS1");
            Assert.IsTrue(libraryController.AddBook(bookBasic1));
        }

        /** Gestion des Utilisateurs **/
        [TestMethod]
        public void Should_add_user()
        {
            init();
            UserDto userDto = new UserDto("login", "name", "firstName", Role.student, null);
            Assert.IsTrue(libraryController.AddUser(userDto, "password"));
        }

        [TestMethod]
        public void Should_not_add_user()
        {
            init();

            //missing UserDto
            Assert.IsFalse(libraryController.AddUser(null, "password"));

            //missing login
            UserDto userDto = new UserDto(null, "name", "firstName", Role.student, null);
            Assert.IsFalse(libraryController.AddUser(userDto, "password"));

            //empty login
            UserDto userDto0 = new UserDto("", "name", "firstName", Role.student, null);
            Assert.IsFalse(libraryController.AddUser(userDto0, "password"));

            //missing name
            UserDto userDto1 = new UserDto("login", null, "firstName", Role.student, null);
            Assert.IsFalse(libraryController.AddUser(userDto1, "password"));

            //empty name
            UserDto userDto2 = new UserDto("login", "", "firstName", Role.student, null);
            Assert.IsFalse(libraryController.AddUser(userDto2, "password"));

            //missing firstname
            UserDto userDto3 = new UserDto("login", "name", null, Role.student, null);
            Assert.IsFalse(libraryController.AddUser(userDto3, "password"));

            //empty firstname
            UserDto userDto4 = new UserDto("login", "name", "", Role.student, null);
            Assert.IsFalse(libraryController.AddUser(userDto4, "password"));

            //missing password
            UserDto userDto7 = new UserDto("login", "name", "firstname", Role.student, null);
            Assert.IsFalse(libraryController.AddUser(userDto7, null));

            //empty password
            UserDto userDto8 = new UserDto("login", "name", "firstname", Role.student, null);
            Assert.IsFalse(libraryController.AddUser(userDto8, ""));

            //existing login
            UserDto userDto9 = new UserDto("login0", "name0", "firstname0", Role.student, null);
            Assert.IsFalse(libraryController.AddUser(userDto9, ""));
        }

        [TestMethod]
        public void Should_remove_user()
        {
            init();
            Assert.IsTrue(libraryController.RemoveUser("login0"));
        }

        [TestMethod]
        public void Should_not_remove_unknown_user()
        {
            init();
            Assert.IsFalse(libraryController.RemoveUser("login100"));
        }

        [TestMethod]
        public void Should_connect_user()
        {
            init();
            UserDto userDto = libraryController.ConnectUser("login0", "password0");
            Assert.IsNotNull(userDto);
            Assert.AreEqual(userDto.Login, "login0");
            Assert.IsNotNull(userDto.Token);
        }

        [TestMethod]
        public void Should_not_connect_user()
        {
            init();
            //missing login
            Assert.IsNull(libraryController.ConnectUser(null, "password0"));
            //empty login
            Assert.IsNull(libraryController.ConnectUser("", "password0"));

            //missing password
            Assert.IsNull(libraryController.ConnectUser("login0", null));

            //empty password
            Assert.IsNull(libraryController.ConnectUser("login0", ""));
        }

        [TestMethod]
        public void Should_logOut_user()
        {
            init();
            UserDto userDto = libraryController.ConnectUser("login0", "password0");
            Assert.IsTrue(libraryController.LogOut(userDto.Token));
        }

        [TestMethod]
        public void Should_not_logOut_user()
        {
            init();
            Assert.IsFalse(libraryController.LogOut(null));
            Assert.IsFalse(libraryController.LogOut(""));
            Assert.IsFalse(libraryController.LogOut("unknown"));
        }

        /** Gestion des Livres **/
        [TestMethod]
        public void Should_add_book()
        {
            init();
            Book bookBasic = new BookBasic("0", "Titre0");
            Assert.IsTrue(libraryController.AddBook(bookBasic));

            Book bookWithDvd = new BookWithDvd("1", "Titre1", 3);
            Assert.IsTrue(libraryController.AddBook(bookWithDvd));
        }

        [TestMethod]
        public void Should_not_add_book()
        {
            init();
            //missing id
            Book bookBasic0 = new BookBasic(null, "Titre0");
            Assert.IsFalse(libraryController.AddBook(bookBasic0));
            //empty id
            Book bookBasic1 = new BookBasic("", "Titre1");
            Assert.IsFalse(libraryController.AddBook(bookBasic1));
            //missing titre
            Book bookBasic2 = new BookBasic("2", null);
            Assert.IsFalse(libraryController.AddBook(bookBasic2));
            //empty titre
            Book bookBasic3 = new BookBasic("3", "");
            Assert.IsFalse(libraryController.AddBook(bookBasic3));
        }

        [TestMethod]
        public void Should_remove_book()
        {
            init();
            Assert.IsTrue(libraryController.RemoveBook("AS0"));
        }

        [TestMethod]
        public void Should_not_remove_book()
        {
            init();
            //missing id
            Assert.IsFalse(libraryController.RemoveBook(null));

            //empty id
            Assert.IsFalse(libraryController.RemoveBook(""));

            //unknown id
            Assert.IsFalse(libraryController.RemoveBook("unknown"));

        }

        [TestMethod]
        public void Should_found_book()
        {
            init();
            List<Book> results = libraryController.SearchBook("TitreAS0");
            Assert.IsNotNull(results);
            Assert.AreEqual(1, results.Count());
        }

        [TestMethod]
        public void Should_not_found_book()
        {
            init();
            List<Book> results = libraryController.SearchBook("UnknownTitle");
            Assert.IsNotNull(results);
            Assert.AreEqual(0, results.Count());
        }
        /*
        [TestMethod]
        public void Should_update_book()
        {
            init();
            Book bookBasic = new BookBasic("0", "Titre0");
            Assert.IsTrue(libraryController.AddBook(bookBasic));

            bookBasic.nextStep();

            Assert.IsTrue(libraryController.UpdateBook(bookBasic));
        }
        */

        /** Notifications **/
        [TestMethod]
        public void Should_get_offline_events()
        {
            init();

            List<Book> books = libraryController.SearchBook("TitreAS0");
            Book book = books.ElementAt(0);
           
            libraryController.NextStepForBook(book.Id, Role.librarian);//stocked
            libraryController.NextStepForBook(book.Id, Role.student);//exposed
            libraryController.NextStepForBook(book.Id, Role.librarian);//borrowed

            UserDto userDto2 = libraryController.ConnectUser("login1", "password1");

            libraryController.NextStepForBook(book.Id, Role.librarian);//Returned

            List<Event> events = libraryController.GetEvents(userDto2.Token);
                       
            Assert.AreEqual(4, events.Count);

            libraryController.NextStepForBook(book.Id, Role.librarian);//Stocked

            events = libraryController.GetEvents(userDto2.Token);

            Assert.AreEqual(1, events.Count);

        }

        [TestMethod]
        public void Should_get_online_events()
        {
            init();
            UserDto userDto = libraryController.ConnectUser("login0", "password0");
            List<Book> books = libraryController.SearchBook("TitreAS0");
            Book book = books.ElementAt(0);
            libraryController.NextStepForBook(book.Id, Role.librarian);
            List<Event> events = libraryController.GetEvents(userDto.Token);

            Assert.AreEqual(1, events.Count);

        }
    }
}
