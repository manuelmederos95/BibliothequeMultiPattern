﻿using BibliothequeMultiPattern.persistences.authenticator.inMemory;
using BibliothequeMultiPattern.services.authenticator.data;
using BibliothequeMultiPattern.services.authenticator.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPatternTest
{
    public class AuthenticateInMemoryImplTest
    {
        IAuthenticatorData authenticator;

        private void initEmpty()
        {
            AuthenticateInMemoryAdapter authenticateInMemoryAdapter = new AuthenticateInMemoryAdapter();
            authenticator = new AuthenticateInMemoryImpl(authenticateInMemoryAdapter);

        }

        private void init()
        {
            AuthenticateInMemoryAdapter authenticateInMemoryAdapter = new AuthenticateInMemoryAdapter();
            authenticator = new AuthenticateInMemoryImpl(authenticateInMemoryAdapter);

            Authenticate authenticate0 = new Authenticate(new AuthenticateId("0"), "login0", "role");
            authenticator.Add(authenticate0, "password0");

            Authenticate authenticate1 = new Authenticate(new AuthenticateId("1"), "login1", "role");
            authenticator.Add(authenticate1, "password1");

            Authenticate authenticate2 = new Authenticate(new AuthenticateId("2"), "login2", "role");
            authenticator.Add(authenticate2, "password2");

        }

        [TestMethod]
        public void Should_add()
        {
            initEmpty();
           Authenticate authenticate = new Authenticate(new AuthenticateId("150"),"login_add", "role");
           Assert.IsTrue(authenticator.Add(authenticate, "password"));
        }

        [TestMethod]
        public void Should_not_add()
        {
            initEmpty();

            //password missing
            Authenticate authenticate = new Authenticate(new AuthenticateId("150"), "login_add", "role");
            Assert.IsFalse(authenticator.Add(authenticate, null));

            //password empty
            Assert.IsFalse(authenticator.Add(authenticate, ""));

            //login missing
            Authenticate authenticate2 = new Authenticate(new AuthenticateId("150"), null, "role");
            Assert.IsFalse(authenticator.Add(authenticate2, "notEmpty"));

            //login empty
            Authenticate authenticate3 = new Authenticate(new AuthenticateId("150"), "", "role");
            Assert.IsFalse(authenticator.Add(authenticate3, "notEmpty"));

            //AuthenticateId missing
            Authenticate authenticate4 = new Authenticate(null, "notEmpty", "role");
            Assert.IsFalse(authenticator.Add(authenticate4, "notEmpty"));

            //AuthenticateId empty
            Authenticate authenticate5 = new Authenticate(new AuthenticateId(""), "notEmpty", "role");
            Assert.IsFalse(authenticator.Add(authenticate5, "notEmpty"));

            //Role missing
            Authenticate authenticate6 = new Authenticate(new AuthenticateId("120"), "notEmpty", null);
            Assert.IsFalse(authenticator.Add(authenticate6, "notEmpty"));

            //Role empty
            Authenticate authenticate7 = new Authenticate(new AuthenticateId("120"), "notEmpty", "");
            Assert.IsFalse(authenticator.Add(authenticate7, "notEmpty"));
        }

        [TestMethod]
        public void Should_not_add_existing_id()
        {
            init();
            Authenticate authenticate0 = new Authenticate(new AuthenticateId("0"), "login0", "role");
            Assert.IsFalse(authenticator.Add(authenticate0, "password"));
        }
        [TestMethod]
        public void Should_get()
        {
            init();
            Assert.IsNotNull(authenticator.GetByLogin("login2"));
        }

        [TestMethod]
        public void Should_not_get()
        {
            init();
            Assert.IsNull(authenticator.GetByLogin("login200"));
        }

        [TestMethod]
        public void Should_remove_found()
        {
            init();
            Assert.IsTrue(authenticator.Remove("login0"));
        }

        [TestMethod]
        public void Should_not_remove_unfound()
        {
            init();
            Assert.IsFalse(authenticator.Remove("login99"));
        }
    }
}
