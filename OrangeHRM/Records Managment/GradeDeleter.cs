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

        public GradeDeleter(IWebDriver webDriver)
        {
            _driver = webDriver;
            _finder = new RecordFinder(webDriver);
        }

        public IWebDriver Driver => _driver;

        public void RemoveRecord(string gradeName = "IlliaMamonov")
        {
            //_driver.NavigateToPayGrades();

            var gradeElement = _finder.Find(gradeName);

            if (gradeName == null)
            {
                return;
            }

            gradeElement.Click();
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
            IWebElement checkBox = _driver.FindElement(By.Id("ohrmList_chkSelectRecord_" + id));
            checkBox.Click();
            _driver.FindElement(_delete).Click();
            Thread.Sleep(2000);
            _driver.FindElement(_ok).Click();
        }
    }
}