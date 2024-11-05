using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Appium.iOS;

namespace SpecFlowBrowserStack
{
	[Binding]
	public class SampleTest

	{
		private readonly IOSDriver<IOSElement> _driver;
		private string? productOnPageText;
		private string? productOnCartText;
		private bool? cartOpened;
		readonly WebDriverWait wait;

		public SampleTest()
		{
			_driver = BrowserStackSpecFlowTest.ThreadLocalDriver.Value;
			wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
		}

		[Given(@"I try to find Text Button in Sample App")]
		public void GivenITryFindTextButton()
		{
			IOSElement textButton = (IOSElement)new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Text Button")));
			textButton.Click();
        }

		[When(@"I type in 'hello@browserstack.com' in the Text Input field")]
		public void WhenITypeInputInTextInputField()
		{
			IOSElement textInput = (IOSElement)new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Text Input")));
			textInput.SendKeys("hello@browserstack.com" + "\n");
        }
		
		[Then(@"I should get the entered text in the Text Output field")]
		public void ThenShouldGetEnteredTextInTextOutputField()
		{
			IOSElement textOutput = (IOSElement)new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Text Output")));
			Assert.That("hello@browserstack.com", Is.EqualTo(textOutput.Text));
        }
	}
}
