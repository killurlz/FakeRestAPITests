using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeRestAPITests.FakeRestAPI.Endpoints
{
    public class BooksEndpoints
    {
        public static string AddABookURI
        {
            get
            {
                return "/api/Books";
            }
        }

        public static Method AddABookMethod
        {
            get
            {
                return Method.POST;
            }
        }

        public static string UpdateABookURI
        {
            get
            {
                return "/api/books/{Id}";
            }
        }

        public static Method UpdateABookMethod
        {
            get
            {
                return Method.PUT;
            }
        }
        public static string DeleteABookByIdURI
        {
            get
            {
                return "/api/books/{Id}";
            }
        }
        public static Method DeleteABookByIDMethod
        {
            get
            {
                return Method.DELETE;
            }
        }
        public static string GetAllBooksURI
        {
            get
            {
                return "/api/books";
            }
        }
        public static Method GetAllBooksMethod
        {
            get
            {
                return Method.GET;
            }
        }
        public static string GetABookByIdURI
        {
            get
            {
                return "/api/books/{Id}";
            }
        }
        public static Method GetABookByIdMethod
        {
            get
            {
                return Method.GET;
            }
        }
    }
}
