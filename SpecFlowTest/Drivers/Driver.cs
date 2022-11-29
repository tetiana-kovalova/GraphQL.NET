using RestSharp;
using TechTalk.SpecFlow;

namespace SpecFlowTest.Drivers
{
    public class Driver
    {
        public Driver(ScenarioContext scenarioContext)
        {
            var restClient = new RestClient(new RestClientOptions
            {
                BaseUrl = new Uri("https://localhost:5001/"),
                RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true
            });

            //Add into ScenarioContext
            scenarioContext.Add("RestClient", restClient);
        }

    }
}
