using OpenQA.Selenium;
using TechTalk.SpecFlow;
using HomeTask.Helpers;

namespace HomeTask.Settings
{
    [Binding]
    public sealed class TestsHooks
    {
        private IWebDriver driver;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = DriverFactory.ReturnDriver(DriverFactory.DriverType.Chrome);
            ScenarioContext.Current["driver"] = driver;
            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
            driver.Dispose();
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
