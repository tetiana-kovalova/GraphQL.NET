using FluentAssertions;
using GraphQLProductApp.Controllers;
using GraphQLProductApp.Data;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowTest.StepDefinitions
{
    [Binding]
    public class BasicOperationSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly RestClient _restClient;
        private Product? _response;

        public BasicOperationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _restClient = _scenarioContext.Get<RestClient>("RestClient");
        }

        [Given(@"user performs GET operation of ""(.*)""")]
        public async Task GivenUserPerformsGetOperationOf(string path, Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            var token = GetToken();

            var request = new RestRequest(path);
            request.AddUrlSegment("id", (int)data.ProductId);
            request.AddHeader("Authorization", $"Bearer {token}");

            _response = await _restClient.GetAsync<Product>(request);
        }

        [Then(@"should receive the product name as ""(.*)""")]
        public void ThenShouldReceiveTheProductNameAs(string value)
        {
            _response.Should().NotBeNull();
            _response!.Name.Should().Be(value);
        }

        private string GetToken()
        {
            var authRequest = new RestRequest("api/Authenticate/Login");

            authRequest.AddJsonBody(new LoginModel
            {
                UserName = "KK",
                Password = "123456"
            });

            var authResponse = _restClient.PostAsync(authRequest).Result.Content;
            authResponse.Should().NotBeNull();

            return JObject.Parse(authResponse!)["token"]!.ToString();
        }
    }
}
