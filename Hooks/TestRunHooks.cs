namespace Highlight.API.Tests.Hooks
{
    using Helpers;
    using TechTalk.SpecFlow;

    /// <summary>
    ///   Hooks that run code before and after a an entire test run with all setup and teardown procedures
    ///   For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
    /// </summary>

    [Binding]
    public static class TestRunHooks
    {
        internal static RestHelper Rest { get; set; }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Rest = new RestHelper();
            Rest.SetUp();
        }
    }
}