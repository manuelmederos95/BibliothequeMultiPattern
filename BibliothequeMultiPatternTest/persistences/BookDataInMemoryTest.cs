using BibliothequeMultiPattern;
using BibliothequeMultiPattern.book;
using BibliothequeMultiPattern.book.data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPatternTest
{
    [TestClass]
    public class BookDataInMemoryTest
    {
        IBookData bookDataInMemory = new BookDataInMemory();

        private void InitData()
        {
            ((BookDataInMemory)bookDataInMemory).Clear();
            BookBasic book0 = new BookBasic("0", "Livre 0");
            bookDataInMemory.Add(book0);
            BookWithDvd book1 = new BookWithDvd("1", "Livre 1", 1);
            bookDataInMemory.Add(book1);
        }

        [TestMethod]
        public void Should_add_complet_basic_book()
        {
            Book bookBasic = new BookBasic("1", "Titre du livre");
            bookDataInMemory.Add(bookBasic);
            Assert.AreEqual(1,bookDataInMemory.Search("Titre du livre").Count());
        }

        [TestMethod]
        public void Should_not_add_incomplet_basic_book()
        {
            ((BookDataInMemory) bookDataInMemory).Clear();
            Book bookBasic2 = new BookBasic("2", "");
            bookDataInMemory.Add(bookBasic2);
            Assert.AreEqual(0, bookDataInMemory.Search("").Count());
            }

        [TestMethod]
        public void Should_find_book_by_title()
        {
            InitData();
            Assert.AreEqual(1, bookDataInMemory.Search("Livre 1").Count());
        }

        [TestMethod]
        public void Should_not_find_unknown_book()
        {
            InitData();
            Assert.AreEqual(0, bookDataInMemory.Search("Livre 10").Count());
        }
    }
}
