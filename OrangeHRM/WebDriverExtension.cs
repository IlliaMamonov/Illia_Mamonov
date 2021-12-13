using OpenQA.Selenium;
using System.Threading;

namespace OrangeHRM
{
    public static class WebDriverExtension
    {
        private static readonly By _admin = By.Id("menu_admin_viewAdminModule");
        private static readonly By _job = By.Id("menu_admin_Job");
        private static readonly By _payGrades = By.Id("menu_admin_viewPayGrades");

        public static void NavigateToPayGrades(this IWebDriver webDriver)
        {
            webDriver.FindElement(_admin).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(_job).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(_payGrades).Click();
            Thread.Sleep(1000);
        }
    }
}