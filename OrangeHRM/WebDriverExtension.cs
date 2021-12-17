using OpenQA.Selenium;
using OrangeHRM.Pages;

namespace OrangeHRM
{
    public static class WebDriverExtension
    {
        private static readonly By _admin = By.Id("menu_admin_viewAdminModule");
        private static readonly By _job = By.Id("menu_admin_Job");
        private static readonly By _payGrades = By.Id("menu_admin_viewPayGrades");

        public static PayGradesPage RedirectToPayGrades(this IWebDriver webDriver)
        {
            webDriver.FindElement(_admin).Click();
            
            webDriver.FindElement(_job).Click();
           
            webDriver.FindElement(_payGrades).Click();
            
            return new PayGradesPage(webDriver);
        }
    }
}