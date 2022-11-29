using Microsoft.AspNetCore.Mvc.Testing;
using RestSharp;

namespace RestSharpTest.Base
{
    public interface IRest
    {
        RestClient RestClient { get; }
    }

    public class Rest : IRest
    {
        public Rest(WebApplicationFactory<GraphQLProductApp.Startup> webApplicationFactory)
        {
            //Spawn our SUT
            var client = webApplicationFactory.CreateDefaultClient();

            RestClient = new RestClient(client, new RestClientOptions
            {
                BaseUrl = new Uri("https://localhost:5001/"),
                RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true
            });
        }
        public RestClient RestClient { get; }
    }
}
