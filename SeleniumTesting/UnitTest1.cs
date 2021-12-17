using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OrangeHRM;
using OrangeHRM.Authorization;
using OrangeHRM.Pages;
using System;
using System.IO;
using System.Linq;

namespace SeleniumTesting
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("OrangeHRM Tests")]
    public sealed class OtangeHRMTests
    {
        private IWebDriver _driver;
        private readonly string _url = "https://opensource-demo.orangehrmlive.com/";
        private readonly string _userName = "Admin";
        private readonly string _password = "admin123";

        [OneTimeSetUp]
        public void Setup()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void Close()
        {
            _driver.Dispose();
        }

        [Test]
        [AllureOwner("IlliaMamonov")]
        public void TestScenario()
        {
            
            int gradeId;
            IWebElement record;
            var name = "IlliaMamonov";
            _driver.Navigate().GoToUrl(_url);
            SignInPage signInPage = new SignInPage(_driver);
            DashBoardPage dashBoardPage = signInPage.SignIn(_userName, _password);
            IWebElement welcomeText = _driver.FindElements(By.Id("welcome")).FirstOrDefault();

            if (welcomeText == null)
            {
                Assert.Fail("Signing in was not successful");
            }

            PayGradesPage payGradesPage = dashBoardPage.RedirectToPayGradesPage();
            GradeAdderPage gradeAdder = payGradesPage.ClickAddButton();
            CurrentGradePage newGradePage = gradeAdder.AddNewGrade(name);
            newGradePage.AssignCurrency(100m, 5000m);
            gradeId = newGradePage.ID;
            payGradesPage = newGradePage.RedirectToPayGradesPage();
            record = payGradesPage.FindRecord(name);

            if (record == null)
            {
                Assert.Fail("A record could not be created");
            }

            payGradesPage.DeleteRecord(gradeId);

            record = payGradesPage.FindRecord(name);

            if (record != null)
            {
                Assert.Fail("A record could not be deleted");
            }

            Assert.Pass();
        }
    }
}