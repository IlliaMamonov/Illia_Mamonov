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
            try
            {
                _driver.NavigateToPayGrades();
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Signing in was not successful");
            }
            record = recordFinder.Find(name);
            if (record != null)
            {
                Assert.Fail("This record already exists");
            }

            _recordAdder.AddNewRecord(name);
            _currencyAssigner.Assign(100m, 10000m);

            _driver.NavigateToPayGrades();

            record = recordFinder.Find(name);

            if (record == null)
            {
                Assert.Fail("Record was not created");
            }

            _gradeDeleter.RemoveRecord(name);

            record = recordFinder.Find(name);

            if (record == null)
            {
                Assert.Pass();
            }

            Assert.Fail("Record was not deleted");
        }
    }
}