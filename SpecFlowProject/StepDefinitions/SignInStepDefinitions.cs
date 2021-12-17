

using NUnit.Framework;
using OpenQA.Selenium;
using OrangeHRM.Authorization;
using SpecFlow.Specs.Drivers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.StepDefinitions
{
    [Binding]

    public sealed class SignInStepDefinitions
    {
        private readonly string _url = "https://opensource-demo.orangehrmlive.com/";
        private readonly IWebDriver _driver;
        private readonly SignInPage _signInPage;

        public SignInStepDefinitions(BrowserDriver browserDriver)
        {
            _signInPage = new SignInPage(browserDriver.Current);
            _driver = browserDriver.Current;
            _driver.Navigate().GoToUrl(_url);
        }

        [Given("the username is (.*)")]
        public void GivenTheUserNameIs(string username)
        {
            _signInPage.SetUserName(username);
        }

        [Given("the password is (.*)")]
        public void GivenThePasswordIs(string password)
        {
            _signInPage.SetPassword(password);
        }

        [When("the submit is clicked")]
        public void WhenSubmitIsClicked()
        {
            _signInPage.ClickSubmit();
        }

        [Then("the signing in should be successful")]
        public void ThenTheResultShouldBe()
        {
            IWebElement welcomeText = _driver.FindElements(By.Id("welcome")).FirstOrDefault();
            if (welcomeText == null)
            {
                Assert.Fail("Signing in was not successful");
            }
            
        }
    }
}