using TechTalk.SpecFlow;
using System;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Appium.iOS;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace SpecFlowBrowserStack
{
	[Binding]
	public class SampleLocalTest
	{
		private readonly IOSDriver<IOSElement> _driver;

		public SampleLocalTest()
		{
			_driver = BrowserStackSpecFlowTest.ThreadLocalDriver.Value;
		}

		[Given(@"I start test on the Local Sample App")]
		public void GivenIStartTestOnLocalApp()
		{
			IOSElement testButton = (IOSElement)new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("TestBrowserStackLocal")));
            testButton.Click();
        }

		[Then(@"I should see \""Up and running\""")]
		public void ThenIShouldSeeLocalText()
		{
			WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(_driver.FindElement(MobileBy.AccessibilityId("ResultBrowserStackLocal")), "Up and running"));
            IOSElement resultElement = (IOSElement)_driver.FindElement(MobileBy.AccessibilityId("ResultBrowserStackLocal"));

            String resultString = resultElement.Text.ToLower();
            if (resultString.Contains("not working"))
            {
                Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
                string screenshot = ss.AsBase64EncodedString;
                byte[] screenshotAsByteArray = ss.AsByteArray;
                ss.SaveAsFile("screenshot", ScreenshotImageFormat.Png);
                ss.ToString();
            }

            String expectedString = "Up and running";

            Assert.True(resultString.Contains(expectedString.ToLower()));
        }
	}
}
