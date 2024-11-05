using TechTalk.SpecFlow;
using System;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Appium.Android;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace SpecFlowBrowserStack
{
	[Binding]
	public class SampleLocalTest
	{
		private readonly AndroidDriver<AndroidElement> _driver;

		public SampleLocalTest()
		{
			_driver = BrowserStackSpecFlowTest.ThreadLocalDriver.Value;
		}

		[Given(@"I start test on the Local Sample App")]
		public void GivenIStartTestOnLocalApp()
		{
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.Id("com.example.android.basicnetworking:id/test_action")));
            searchElement.Click();
            AndroidElement testElement = (AndroidElement)new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.ClassName("android.widget.TextView")));
        }

		[Then(@"I should see \""Up and running\""")]
		public void ThenIShouldSeeLocalText()
		{
            ReadOnlyCollection<AndroidElement> allTextViewElements = _driver.FindElements(By.ClassName("android.widget.TextView"));

            Thread.Sleep(5000);

            foreach (AndroidElement textElement in allTextViewElements)
            {
                if (textElement.Text.Contains("The active connection is"))
                {
                    Assert.True(textElement.Text.Contains("The active connection is wifi"), "Incorrect Text");
                }
            }
        }
	}
}
