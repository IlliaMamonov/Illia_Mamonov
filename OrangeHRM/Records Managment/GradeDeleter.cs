using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.Threading;

namespace OrangeHRM.Records_Managment
{
    public sealed class GradeDeleter : IRecordDeleter
    {
        private readonly By _delete = By.Id("btnDelete");
        private readonly IWebDriver _driver;
        private readonly RecordFinder _finder;
        private readonly By _ok = By.Id("dialogDeleteBtn");
        private By _checkbox;

        public GradeDeleter(IWebDriver webDriver)
        {
            _driver = webDriver;
            _finder = new RecordFinder(webDriver);
        }

        public IWebDriver Driver => _driver;

        public void RemoveRecord(string gradeName = "IlliaMamonov")
        {
            var currentRecord = _finder.Find(gradeName);

            currentRecord.Click();
            Thread.Sleep(1000);
            var currentUrl = _driver.Url;

            var regex = @"\d";
            var matches = Regex.Matches(currentUrl, regex);
            var id = "";
            foreach (Match match in matches)
            {
                id += match.Value;
            }
            _driver.NavigateToPayGrades();
            _checkbox = By.Id("ohrmList_chkSelectRecord_" + id);
            IWebElement checkBox = _driver.FindElement(_checkbox);
            checkBox.Click();
            _driver.FindElement(_delete).Click();
            Thread.Sleep(2000);
            _driver.FindElement(_ok).Click();
        }
    }
}