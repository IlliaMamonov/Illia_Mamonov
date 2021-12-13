using OpenQA.Selenium;

namespace OrangeHRM.Authorization
{
    public sealed class OrangeHRMAuthorizer : IWebSiteAuthorizer
    {
        private readonly By _password = By.Name("txtPassword");
        private readonly By _submit = By.Name("Submit");
        private readonly By _userName = By.Name("txtUsername");
        private readonly IWebDriver _driver;

        public OrangeHRMAuthorizer(IWebDriver webDriver) => _driver = webDriver;

        public IWebDriver Driver => _driver;

        public void SignIn(string username, string password)
        {
            _driver.FindElement(_userName).SendKeys(username);
            _driver.FindElement(_password).SendKeys(password);
            _driver.FindElement(_submit).Click();
        }
    }
}