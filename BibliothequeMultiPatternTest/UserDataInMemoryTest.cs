using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliothequeMultiPattern;
using System;

namespace BibliothequeMultiPatternTest
{
    [TestClass]
    public class UserDataInMemoryTest
    {
        IUserData userDataInMemory = UserDataInMemory.getInstance();

        private void InitData()
        {
            ((UserDataInMemory) userDataInMemory).Clear();
            IUser student3 = new Student("NAME3", "First3", "login3", "azerty");
            userDataInMemory.Add(student3);
            IUser student4 = new Student("NAME4", "First3", "login4", "azerty");
            userDataInMemory.Add(student4);
        }

        [TestMethod]
        public void Should_add_complet_student_user()
        {
            IUser student1 = new Student("NAME1", "First1","login1","azerty");
            Assert.IsTrue(userDataInMemory.Add(student1));
        }

        [TestMethod]
        public void Should_not_add_incomplet_student_user()
        {
            IUser student2 = new Student("NAME2", "", "login2", "");
            Assert.IsFalse(userDataInMemory.Add(student2));
        }

        [TestMethod]
        public void Should_connect_user_by_login()
        {
            InitData();
            Assert.IsNotNull(userDataInMemory.Connect("login3", "azerty"));
        }

        [TestMethod]
        public void Should_not_connect_invalid_login()
        {
            InitData();
            Assert.IsNull(userDataInMemory.Connect("login_false", "azerty"));
        }

        [TestMethod]
        public void Should_not_connect_invalid_password()
        {
            InitData();
            Assert.IsNull(userDataInMemory.Connect("login3", "wrong"));
        }

        [TestMethod]
        public void Should_not_connect_with_empty_data()
        {
            ((UserDataInMemory)userDataInMemory).Clear();
            Assert.IsNull(userDataInMemory.Connect("login3", "azerty"));
        }

        [TestMethod]
        public void Should_not_remove_not_found_user()
        {
            InitData();
            Assert.IsFalse(userDataInMemory.Remove("Unknown"));
            Assert.AreEqual(2, ((UserDataInMemory)userDataInMemory).GetCount());
        }

        [TestMethod]
        public void Should_remove_found_user()
        {
            InitData();
            Assert.IsTrue(userDataInMemory.Remove("login3"));
            Assert.AreEqual(1, ((UserDataInMemory)userDataInMemory).GetCount());
        }

        [TestMethod]
        public void Should_not_remove_with_empty_data()
        {
            Assert.IsFalse(userDataInMemory.Remove("login3"));
        }
    }
}
