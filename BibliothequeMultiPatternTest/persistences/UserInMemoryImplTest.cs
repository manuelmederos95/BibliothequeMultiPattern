using BibliothequeMultiPattern.model;
using BibliothequeMultiPattern.persistences.authenticator.inMemory;
using BibliothequeMultiPattern.persistences.users;
using BibliothequeMultiPattern.persistences.users.inMemory;
using BibliothequeMultiPattern.services.authenticator.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPatternTest
{
    [TestClass]
    public class UserInMemoryImplTest
    {
        IUserData userData;

        private void initEmpty()
        {
            UserInMemoryAdapter userInMemoryAdapter = new UserInMemoryAdapter();
            userData = new UserInMemoryImpl(userInMemoryAdapter);
        }

        private void init()
        {
            UserInMemoryAdapter userInMemoryAdapter = new UserInMemoryAdapter();
            userData = new UserInMemoryImpl(userInMemoryAdapter);

            User user1 = new User(new UserId("1"),"Name1","FirstName1",new AuthenticateId("1"));
            userData.Add(user1);

            User user2 = new User(new UserId("2"), "Name2", "FirstName2", new AuthenticateId("2"));
            userData.Add(user2);

            User user3 = new User(new UserId("3"), "Name3", "FirstName3", new AuthenticateId("3"));
            userData.Add(user3);

        }

        [TestMethod]
        public void Should_add()
        {
            initEmpty();
            User user0 = new User(new UserId("0"), "Name0", "FirstName0", new AuthenticateId("0"));
            Assert.IsTrue(userData.Add(user0));
        }

        [TestMethod]
        public void Should_not_add()
        {
            initEmpty();

            //userId missing
            User user1 = new User(null, "Name1", "FirstName1", new AuthenticateId("1"));
            Assert.IsFalse(userData.Add(user1));

            //userId empty
            User user2 = new User(new UserId(""), "Name2", "FirstName2", new AuthenticateId("2"));
            Assert.IsFalse(userData.Add(user2));

            //name missing
            User user3 = new User(new UserId("3"), null, "FirstName3", new AuthenticateId("3"));
            Assert.IsFalse(userData.Add(user3));

            //name empty
            User user4 = new User(new UserId("4"), "", "FirstName4", new AuthenticateId("4"));
            Assert.IsFalse(userData.Add(user4));

            //firstname missing
            User user5 = new User(new UserId("5"), "Name5", null, new AuthenticateId("5"));
            Assert.IsFalse(userData.Add(user5));

            //firstname empty
            User user6 = new User(new UserId("6"), "Name6", "", new AuthenticateId("6"));
            Assert.IsFalse(userData.Add(user6));

            //authenticateId missing
            User user7 = new User(new UserId("7"), "Name7", "FirstName7", null);
            Assert.IsFalse(userData.Add(user7));

            //authenticateId empty
            User user8 = new User(new UserId("8"), "Name8", "FirstName8", new AuthenticateId(""));
            Assert.IsFalse(userData.Add(user8));

        }

        [TestMethod]
        public void Should_not_add_existing_id()
        {
            init();
            User user9 = new User(new UserId("1"), "Name1", "FirstName1", new AuthenticateId("1"));
            Assert.IsFalse(userData.Add(user9));
        }

        [TestMethod]
        public void Should_get_by_authentication_id()
        {
            init();
            Assert.IsNotNull(userData.GetByAuthenticationId("1"));
        }

        [TestMethod]
        public void Should_get_by_user_id()
        {
            init();
            Assert.IsNotNull(userData.GetByUserId("1"));
        }

        [TestMethod]
        public void Should_not_get()
        {
            init();
            //Missing userId
            Assert.IsNull(userData.GetByUserId("100"));

            //Missing authenticationId
            Assert.IsNull(userData.GetByUserId("100"));
        }

        [TestMethod]
        public void Should_remove_found()
        {
            init();
            Assert.IsTrue(userData.Remove("1"));
        }

        [TestMethod]
        public void Should_not_remove_unfound()
        {
            init();
            Assert.IsFalse(userData.Remove("100"));
        }

    }
}
