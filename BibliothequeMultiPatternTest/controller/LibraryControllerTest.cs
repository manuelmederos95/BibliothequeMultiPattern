using BibliothequeMultiPattern;
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

            UserDto userDto0 = new UserDto("login0", "name0", "firstname0", "student", null);
            libraryController.Add(userDto0, "password0");

            UserDto userDto1 = new UserDto("login1", "name1", "firstname1", "student", null);
            libraryController.Add(userDto1, "password1");

            UserDto userDto2 = new UserDto("login2", "name2", "firstname2", "admin", null);
            libraryController.Add(userDto1, "password2");

            UserDto userDto3 = new UserDto("login3", "name3", "firstname3", "librarian", null);
            libraryController.Add(userDto3, "password3");
        }

        /** Gestion des Utilisateurs **/
        [TestMethod]
        public void Should_add_user()
        {
            init();
            UserDto userDto = new UserDto("login","name","firstName","student",null);
            Assert.IsTrue(libraryController.Add(userDto,"password"));
        }

        [TestMethod]
        public void Should_not_add_user()
        {
            init();

            //missing UserDto
            Assert.IsFalse(libraryController.Add(null, "password"));

            //missing login
            UserDto userDto = new UserDto(null, "name", "firstName", "student", null);
            Assert.IsFalse(libraryController.Add(userDto, "password"));

            //empty login
            UserDto userDto0 = new UserDto("", "name", "firstName", "student", null);
            Assert.IsFalse(libraryController.Add(userDto0, "password"));

            //missing name
            UserDto userDto1 = new UserDto("login", null, "firstName", "student", null);
            Assert.IsFalse(libraryController.Add(userDto1, "password"));

            //empty name
            UserDto userDto2 = new UserDto("login", "", "firstName", "student", null);
            Assert.IsFalse(libraryController.Add(userDto2, "password"));

            //missing firstname
            UserDto userDto3 = new UserDto("login", "name", null, "student", null);
            Assert.IsFalse(libraryController.Add(userDto3, "password"));

            //empty firstname
            UserDto userDto4 = new UserDto("login", "name", "", "student", null);
            Assert.IsFalse(libraryController.Add(userDto4, "password"));

            //missing role
            UserDto userDto5 = new UserDto("login", "name", "firstname", null, null);
            Assert.IsFalse(libraryController.Add(userDto5, "password"));

            //empty role
            UserDto userDto6 = new UserDto("login", "name", "firstname", "", null);
            Assert.IsFalse(libraryController.Add(userDto6, "password"));

            //missing password
            UserDto userDto7 = new UserDto("login", "name", "firstname", "student", null);
            Assert.IsFalse(libraryController.Add(userDto7, null));

            //empty password
            UserDto userDto8 = new UserDto("login", "name", "firstname", "student", null);
            Assert.IsFalse(libraryController.Add(userDto8, ""));

            //existing login
            UserDto userDto9 = new UserDto("login0", "name0", "firstname0", "student", null);
            Assert.IsFalse(libraryController.Add(userDto9, ""));
        }

        [TestMethod]
        public void Should_remove_user()
        {
            init();
            Assert.IsTrue(libraryController.Remove("login0"));
        }

        [TestMethod]
        public void Should_not_remove_unknown_user()
        {
            init();
            Assert.IsFalse(libraryController.Remove("login100"));
        }

        [TestMethod]
        public void Should_connect_user()
        {
            init();
            UserDto userDto = libraryController.Connect("login0", "password0");
            Assert.IsNotNull(userDto);
            Assert.AreEqual(userDto.Login, "login0");
            Assert.IsNotNull(userDto.Token);
        }

        [TestMethod]
        public void Should_not_connect_user()
        {
            init();
            //missing login
            Assert.IsNull(libraryController.Connect(null, "password0"));
            //empty login
            Assert.IsNull(libraryController.Connect("", "password0"));

            //missing password
            Assert.IsNull(libraryController.Connect("login0", null));

            //empty password
            Assert.IsNull(libraryController.Connect("login0", ""));
        }

        [TestMethod]
        public void Should_logOut_user()
        {
            init();
            UserDto userDto = libraryController.Connect("login0", "password0");
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
          
        }

        [TestMethod]
        public void Should_not_add_book()
        {
            init();

        }
    }
}
