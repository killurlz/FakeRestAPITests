using FakeRestAPITests.FakeRestAPI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeRestAPITests.FakeRestAPI
{
    public interface IFakeRestAPIClient
    {
        IRestResponse AddBook(Book book);
        IRestResponse UpdateABook(Book book, int id);
        IRestResponse DeleteABook(int id);
        IRestResponse GetAllBooks();
        IRestResponse GetABookById(int id);
    }
    
}
