namespace Highlight.API.Tests.Step_Definitions
{
    using Helpers;
    using Hooks;
    using NUnit.Framework;
    using TechTalk.SpecFlow;
    using System.Collections.Generic;

    [Binding]
    internal class CommonSteps 
    {
        private PowerPlantsDTO queryResult;

        public CommonSteps()
        {
            this.queryResult = null;
        }

        private RestHelper Rest
        {
            get { return TestRunHooks.Rest; }
        }

        [When(@"I query the Carbon Monitoring page for (.*), (.*), (.*)")]
        public void WhenIQueryTheCarbonMonitoringPage(string location, string limit, string colour)
        {
            var filterDict = new Dictionary<string, string>();
            filterDict.Add("location", location);
            filterDict.Add("limit", limit);
            filterDict.Add("colour", colour);
            this.queryResult = Rest.GetParameterisedQuery(filterDict);
        }

        [Then(@"the results contains (.*)")]
        public void ThenTheResultsContains(string expectedEntry)
        {
            if (this.queryResult == null)
            {
                Assert.Fail("Output could not be foumd!");
            }
            else
            {
                Assert.That(this.queryResult[0].name, Is.EqualTo(expectedEntry), 
                            string.Format("'{0}' is not what was expected", expectedEntry));
            }
        }

    }
}