using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System.Collections.ObjectModel;

namespace SpecFlowBrowserStack
{
	[Binding]
	public class SampleTest

	{
		private readonly AndroidDriver<AndroidElement> _driver;


		public SampleTest()
		{
			_driver = BrowserStackSpecFlowTest.ThreadLocalDriver.Value;
		}

		[Given(@"I try to search using Wikipedia App")]
		public void GivenITrySearchWikipediaApp()
		{
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Search Wikipedia")));
            searchElement.Click();
        }

		[Then(@"I search with keyword BrowserStack")]
		public void ThenISearchKeywordBrowserStack()
		{
            AndroidElement insertTextElement = (AndroidElement)new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.Id("org.wikipedia.alpha:id/search_src_text")));
            insertTextElement.SendKeys("BrowserStack");
            Thread.Sleep(5000);
        }
		
		[Then(@"The search results should be listed")]
		public void ThenSearchResultsShouldBeListed()
		{
            ReadOnlyCollection<AndroidElement> allProductsName = _driver.FindElements(By.ClassName("android.widget.TextView"));
            Assert.True(allProductsName.Count > 0);
        }
	}
}
