using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OrangeHRM;
using OrangeHRM.Authorization;
using OrangeHRM.Records_Managment;

namespace SeleniumTesting
{
    [TestFixture]
    public sealed class OtangeHRMTests
    {
        private IWebDriver _driver;
        private IWebSiteAuthorizer _authorizer;
        private IRecordAdder _recordAdder;
        private CurrencyAssigner _currencyAssigner;
        private GradeDeleter _gradeDeleter;
        private readonly string _url = "https://opensource-demo.orangehrmlive.com/";
        private readonly string _userName = "Admin";
        private readonly string _password = "admin123";

        [OneTimeSetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _authorizer = new OrangeHRMAuthorizer(_driver);
            _recordAdder = new GradeAdder(_driver);
            _currencyAssigner = new CurrencyAssigner(_driver);
            _gradeDeleter = new GradeDeleter(_driver);
        }

        [OneTimeTearDown]
        public void Close()
        {
            _driver.Dispose();
        }

        [Test]
        public void TestScenario()
        {
            IWebElement record;
            var recordFinder = new RecordFinder(_driver);
            var name = "IlliaMamonov";
            _driver.Navigate().GoToUrl(_url);
            _authorizer.SignIn(_userName, _password);
            _driver.NavigateToPayGrades();

            try
            {
                _recordAdder.AddNewRecord(name);
                _currencyAssigner.Assign(100m, 10000m);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("This record already exists");
            }

            _driver.NavigateToPayGrades();

            try
            {
                record = recordFinder.Find(name);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Record was not created");
            }

            // _driver.NavigateToPayGrades();

            _gradeDeleter.RemoveRecord(name);

            try
            {
                record = recordFinder.Find(name);
            }
            catch (NoSuchElementException)
            {
                Assert.Pass();
            }

            Assert.Fail("Record was not deleted");
        }
    }
}