using OpenQA.Selenium;

namespace OrangeHRM.Records_Managment
{
    public sealed class GradeAdder : IRecordAdder
    {

        private readonly By _addGrade = By.Name("btnAdd");
        private readonly By _gradeName = By.Id("payGrade_name");
        private readonly By _save = By.Name("btnSave");
        private readonly IWebDriver _driver;

        public GradeAdder(IWebDriver webDriver) => _driver = webDriver;

        public IWebDriver Driver => _driver;

        public void AddNewRecord(string name = "IlliaMamonov")
        {
            _driver.FindElement(_addGrade).Click();
            _driver.FindElement(_gradeName).SendKeys(name);
            _driver.FindElement(_save).Click();
        }
    }
}