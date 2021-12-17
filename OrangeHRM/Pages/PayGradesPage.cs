using OpenQA.Selenium;
using System.Linq;

namespace OrangeHRM.Pages
{
    public sealed class PayGradesPage : IPage
    {
        private readonly By _addGrade = By.Name("btnAdd");
        private readonly By _delete = By.Id("btnDelete");
        private readonly IWebDriver _driver;

        public PayGradesPage(IWebDriver webDriver) => _driver = webDriver;

        public IWebDriver Driver => _driver;

        public GradeAdderPage ClickAddButton()
        {
            _driver.FindElement(_addGrade).Click();

            return new GradeAdderPage(_driver);
        }

        /// <summary>
        /// This method deletes a record
        /// </summary>
        /// <param name="id"> ID of the record to be deleted</param>
        /// <returns>A PayGradesPage object</returns>
        public PayGradesPage DeleteRecord(int id)
        {
            var checkBox = By.Id("ohrmList_chkSelectRecord_" + id.ToString());
            var checkBoxElement = _driver.FindElements(checkBox).FirstOrDefault();
            if (checkBoxElement == null)
            {
                return this;
            }
            checkBoxElement.Click();
            _driver.FindElement(_delete).Click();
            By _ok = By.Id("dialogDeleteBtn");
            _driver.FindElement(_ok).Click();
            return this;
        }

        /// <summary>
        /// This method deletes a record
        /// </summary>
        /// <param name="name">Name of the record to be deleted</param>
        /// <returns>A PayGradesPage object</returns>
        public PayGradesPage DeleteRecord(string name)
        {
            IWebElement record = FindRecord(name);

            if (record == null)
            {
                return this;
            }

            FindRecord(name).Click();

            var currentGradePage = new CurrentGradePage(_driver);
            var id = currentGradePage.ID;
            currentGradePage.RedirectToPayGradesPage();
            DeleteRecord(id);
            return this;
        }

        public IWebElement FindRecord(string name = "IlliaMamonov")
        {
            var elements = _driver.FindElements(By.XPath($"//*[contains(text(), '{name}')]"));

            return elements.FirstOrDefault();
        }
    }
}