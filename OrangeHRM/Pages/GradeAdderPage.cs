using OpenQA.Selenium;

namespace OrangeHRM.Pages
{
    public sealed class GradeAdderPage : IPage
    {
        private readonly By _gradeName = By.Id("payGrade_name");
        private readonly By _save = By.Name("btnSave");
        private readonly IWebDriver _driver;

        public GradeAdderPage(IWebDriver webDriver) => _driver = webDriver;

        public IWebDriver Driver => _driver;

        public CurrentGradePage AddNewGrade(string name = "IlliaMamonov")
        {
            SetName(name);
            _driver.FindElement(_save).Click();
            return new CurrentGradePage(_driver);
        }

        public void SetName(string name = "IlliaMamonov")
        {
            _driver.FindElement(_gradeName).SendKeys(name);
        }
    }
}