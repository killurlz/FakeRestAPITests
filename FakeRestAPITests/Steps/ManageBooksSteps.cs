using FakeRestAPITests.FakeRestAPI;
using FakeRestAPITests.FakeRestAPI.Models;
using FluentAssertions;
using FluentAssertions.Extensions;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace FakeRestAPITests.Steps
{
    [Binding]
    public class ManageBooksSteps
    {
        private static string newBookKey = "new-book";
        private static string newBookResponseKey = "new-book-response";
        private static string deletedBookResponseKey = "deleted-book-response";
        private static string allBooksResponseKey = "all-books-response";
        private static string getBookByIdResponseKey = "get-book-response";
        private readonly IFakeRestAPIClient fakeRestAPIClient;
        private readonly ScenarioContext scenarioContext;

        public ManageBooksSteps(IFakeRestAPIClient fakeRestAPIClient, ScenarioContext scenarioContext)
        {

            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.fakeRestAPIClient = fakeRestAPIClient;
            this.scenarioContext = scenarioContext;
        }

        [When(@"a user requests to add a book using (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void WhenAUserRequestsToAddABookUsingAnd(int id, string title, string description, int pageCount, string excerpt, string publishDate)
        {
            Book newBook = new Book()
            {
                Id = id,
                Title = title,
                Description = description,
                PageCount = pageCount,
                Excerpt = excerpt,
                PublishDate = publishDate,
            };

            IRestResponse newBookResponse = this.fakeRestAPIClient.AddBook(newBook);
            this.scenarioContext.Add(newBookKey, newBook);
            this.scenarioContext.Add(newBookResponseKey, newBookResponse);
        }

        [Then(@"an OK response containing the newly added book's information should be returned to the user")]
        public void ThenAnOKResponseContainingTheNewlyAddedBookSInformationShouldBeReturnedToTheUser()
        {
            IRestResponse newBookResponse = this.scenarioContext.Get<IRestResponse>(newBookResponseKey);
            Book expectedBook = this.scenarioContext.Get<Book>(newBookKey);
            Book newlyAddedBook = new JsonDeserializer().Deserialize<Book>(newBookResponse);

            newBookResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            newlyAddedBook.Should().BeEquivalentTo(expectedBook);
        }

        [When(@"a user requests to update a book using (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void WhenAUserRequestsToUpdateABookUsingUpdatedTitleUpdatedDescriptionAndBookExcerpt(int id, string title, string description, int pageCount, string excerpt, string publishDate)
        {
            Book updatedBook = new Book()
            {
                Id = id,
                Title = title,
                Description = description,
                PageCount = pageCount,
                Excerpt = excerpt,
                PublishDate = publishDate,
            };

            IRestResponse updateBookResponse = this.fakeRestAPIClient.UpdateABook(updatedBook, id);
            this.scenarioContext.Add(newBookKey, updatedBook);
            this.scenarioContext.Add(newBookResponseKey, updateBookResponse);
        }

        [Then(@"an OK response containing the updated book's information should be returned to the user")]
        public void ThenAnOKResponseContainingTheUpdatedBookSInformationShouldBeReturnedToTheUser()
        {
            IRestResponse updatedBookResponse = this.scenarioContext.Get<IRestResponse>(newBookResponseKey);
            Book expectedBook = this.scenarioContext.Get<Book>(newBookKey);
            Book updateBook = new JsonDeserializer().Deserialize<Book>(updatedBookResponse);

            updatedBookResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            updateBook.Should().BeEquivalentTo(expectedBook);
        }

        [When(@"a user requests to delete a certain book using (.*)")]
        public void WhenAUserRequestsToDeleteACertainBookUsing(int id)
        {
            IRestResponse deletedBookResponse = this.fakeRestAPIClient.DeleteABook(id);

            this.scenarioContext.Add(deletedBookResponseKey, deletedBookResponse);
        }

        [Then(@"an OK response containing an empty body is returned to the user")]
        public void ThenAnOKResponseContainingAnEmptyBodyIsReturnedToTheUser()
        {
            IRestResponse deletedBookResponse = this.scenarioContext.Get<IRestResponse>(deletedBookResponseKey);

            deletedBookResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            deletedBookResponse.Content.Should().BeEmpty();
        }

        [When(@"a user requests to read all books")]
        public void WhenAUserRequestsToReadAllBooks()
        {
            this.scenarioContext.Add(allBooksResponseKey, this.fakeRestAPIClient.GetAllBooks());
        }
        
        [Then(@"an OK response containing the following books should be returned to the user")]
        public void ThenAnOKResponseContainingTheFollowingBooksShouldBeReturnedToTheUser(Table table)
        {
            IRestResponse allBooksResponse = this.scenarioContext.Get<IRestResponse>(allBooksResponseKey);
            List<Book> allBooks = new JsonDeserializer().Deserialize<List<Book>>(allBooksResponse);
            List<Book> expectedBooks = table.CreateSet<Book>().ToList();

            foreach(Book book in allBooks)
            {
                book.Description = book.Description.Replace("\r\n", string.Empty);
                book.Excerpt = book.Excerpt.Replace("\r\n", string.Empty);
                book.PublishDate = null;
            }

            allBooksResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            allBooks.ElementAt(0).Should().Equals(expectedBooks.ElementAt(0));
            allBooks.ElementAt(99).Should().Equals(expectedBooks.ElementAt(1));
            allBooks.ElementAt(199).Should().Equals(expectedBooks.ElementAt(2));
        }
        [When(@"a user requests to read a book using id:(.*)")]
        public void WhenAUserRequestsToReadABookUsingId(int id)
        {
            IRestResponse getBookByIdResponse = this.fakeRestAPIClient.GetABookById(id);
            this.scenarioContext.Add(getBookByIdResponseKey, getBookByIdResponse);
        }

        [Then(@"an OK response containing the following book's information should be returned to the user")]
        public void ThenAnOKResponseContainingTheFollowingBookSInformationShouldBeReturnedToTheUser(Table table)
        {
            IRestResponse getBookByIdResponse = this.scenarioContext.Get<IRestResponse>(getBookByIdResponseKey);
            Book book = new JsonDeserializer().Deserialize<Book>(getBookByIdResponse);
            book.Description = book.Description.Replace("\r\n", string.Empty);
            book.Excerpt = book.Excerpt.Replace("\r\n", string.Empty);
            book.PublishDate = null;
            Book expectedBook = table.CreateSet<Book>().ToList().ElementAt(0);

            book.Should().Equals(expectedBook);
        }


    }
}
