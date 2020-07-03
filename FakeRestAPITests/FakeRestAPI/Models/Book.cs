using System;
using System.Collections.Generic;
using System.Text;

namespace FakeRestAPITests.FakeRestAPI.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int PageCount { get; set; }

        public string Excerpt { get; set; }

        public string PublishDate { get; set; }
    }
}
