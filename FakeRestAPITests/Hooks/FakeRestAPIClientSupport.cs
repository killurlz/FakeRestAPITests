namespace FakeRestAPITests.Hooks
{
    using BoDi;
    using FakeRestAPITests.FakeRestAPI;
    using RestSharp;
    using TechTalk.SpecFlow;

    [Binding]
    public class FakeRestAPIClientSupport
    {
        private static string fakeRestAPIUrl = "http://fakerestapi.azurewebsites.net/";
        private readonly IObjectContainer objectContainer;

        public FakeRestAPIClientSupport(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeFakeRestAPIClient()
        {
            IFakeRestAPIClient fakeRestAPIClient = new FakeRestAPIClient(new RestClient(fakeRestAPIUrl));
            this.objectContainer.RegisterInstanceAs<IFakeRestAPIClient>(fakeRestAPIClient);
        }
    }
}
