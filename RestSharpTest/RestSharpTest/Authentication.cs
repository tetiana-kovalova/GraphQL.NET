using FluentAssertions;
using GraphQLProductApp.Controllers;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharpTest.Base;
using Xunit;

namespace RestSharpTest
{
    public class Authentication
    {
        private readonly RestClient _client;
        public Authentication(IRest rest) => _client = rest.RestClient;

        [Fact]
        public void GetJwtTokenTest()
        {
            var request = new RestRequest("api/Authenticate/Login");

            request.AddJsonBody(new LoginModel
            {
                UserName = "tanya",
                Password = "321"
            });

            var response = _client.PostAsync(request).Result.Content;
            response.Should().NotBeNullOrEmpty();

            var token = JObject.Parse(response!)["token"];
            token.Should().NotBeNull();
        }
    }
}
