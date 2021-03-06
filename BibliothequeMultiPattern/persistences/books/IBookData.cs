﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMultiPattern.book.data
{
    public interface IBookData
    {
        bool Add(Book book);
        bool Remove(string id);
        bool Update(Book book);
        List<Book> Search(string value);
        Book GetById(string id);
    }
}
