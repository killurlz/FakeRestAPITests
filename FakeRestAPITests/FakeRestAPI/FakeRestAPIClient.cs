namespace FakeRestAPITests.FakeRestAPI
{
    using FakeRestAPITests.FakeRestAPI.Endpoints;
    using FakeRestAPITests.FakeRestAPI.Models;
    using RestSharp;

    public class FakeRestAPIClient : IFakeRestAPIClient
    {
        private readonly IRestClient restClient;

        public FakeRestAPIClient(IRestClient restClient)
        {
            this.restClient = restClient;
        }

        public IRestResponse AddBook(Book book)
        {
            IRestRequest request = new RestRequest(BooksEndpoints.AddABookURI, BooksEndpoints.AddABookMethod);
            request.AddJsonBody(book);

            return this.restClient.Execute<Book>(request);
        }

        public IRestResponse UpdateABook(Book book, int id)
        {
            IRestRequest request = new RestRequest(BooksEndpoints.UpdateABookURI, BooksEndpoints.UpdateABookMethod);
            request.AddParameter("Id", id, ParameterType.UrlSegment);
            request.AddJsonBody(book);

            return this.restClient.Execute<Book>(request);
        }

        public IRestResponse DeleteABook(int id)
        {
            IRestRequest request = new RestRequest(BooksEndpoints.DeleteABookByIdURI, BooksEndpoints.DeleteABookByIDMethod);
            request.AddParameter("Id", id, ParameterType.UrlSegment);

            return this.restClient.Execute(request);
        }

        public IRestResponse GetAllBooks()
        {
            IRestRequest request = new RestRequest(BooksEndpoints.GetAllBooksURI, BooksEndpoints.GetAllBooksMethod);

            return this.restClient.Execute(request);
        }

        public IRestResponse GetABookById(int id)
        {
            IRestRequest request = new RestRequest(BooksEndpoints.GetABookByIdURI, BooksEndpoints.GetABookByIdMethod);
            request.AddParameter("Id", id, ParameterType.UrlSegment);

            return this.restClient.Execute(request);
        }
    }
}
