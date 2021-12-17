using OpenQA.Selenium;
using OrangeHRM.Pages;

namespace OrangeHRM.Authorization
{
    public sealed class SignInPage : IPage
    {
        private readonly By _password = By.Name("txtPassword");
        private readonly By _submit = By.Name("Submit");
        private readonly By _userName = By.Name("txtUsername");
        private readonly IWebDriver _driver;

        public SignInPage(IWebDriver webDriver) => _driver = webDriver;

        public IWebDriver Driver => _driver;

        public void ClickSubmit()
        {
            _driver.FindElement(_submit).Click();
        }

        public void SetPassword(string password)
        {
            _driver.FindElement(_password).SendKeys(password);
        }

        public void SetUserName(string username)
        {
            _driver.FindElement(_userName).SendKeys(username);
        }

        public DashBoardPage SignIn(string username, string password)
        {
            SetUserName(username);
            SetPassword(password);
            ClickSubmit();
            return new DashBoardPage(_driver);
        }
    }
}