using SpecFlowTest.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowTest.Hooks
{
    [Binding]
    public class Hook
    {
        private readonly ScenarioContext _scenarioContext;

        public Hook(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void InitializeDriver()
        {
            Driver driver = new Driver(_scenarioContext);
        }
    }
}
