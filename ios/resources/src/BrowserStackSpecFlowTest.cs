using System;
using TechTalk.SpecFlow;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using System.Threading;
using OpenQA.Selenium.Appium.iOS;

namespace SpecFlowBrowserStack
{
	[Binding]
	public class BrowserStackSpecFlowTest
	{
		private FeatureContext _featureContext;
		private ScenarioContext _scenarioContext;

		public static ThreadLocal<IOSDriver<IOSElement>> ThreadLocalDriver = new ThreadLocal<IOSDriver<IOSElement>>();
		private static readonly ILog log = LogManager.GetLogger(typeof(BrowserStackSpecFlowTest));

		public BrowserStackSpecFlowTest(FeatureContext featureContext, ScenarioContext scenarioContext)
		{
			_featureContext = featureContext;
			_scenarioContext = scenarioContext;
		}


		[BeforeScenario]
		public static void Initialize(ScenarioContext scenarioContext)
		{
            AppiumOptions appiumOptions = new AppiumOptions();
            ThreadLocalDriver.Value = new IOSDriver<IOSElement>(new Uri("http://127.0.0.1:4723/wd/hub"), appiumOptions);
        }


		[AfterScenario]
		public static void TearDown(ScenarioContext scenarioContext)
		{
			Shutdown();
		}

		protected static void Shutdown()
		{
			if (ThreadLocalDriver.IsValueCreated)
			{
				ThreadLocalDriver.Value?.Quit();
			}
		}
	}
}
