using OpenQA.Selenium;

namespace OrangeHRM.Authorization
{
    public interface IWebSiteAuthorizer
    {
        IWebDriver Driver { get; }

        void SignIn(string username, string password);
    }
}