using OpenQA.Selenium;

namespace OrangeHRM.Pages
{
    public sealed class DashBoardPage : IPage
    {
        private readonly IWebDriver _driver;

        public DashBoardPage(IWebDriver webDriver) => _driver = webDriver;

        public IWebDriver Driver => _driver;

        public PayGradesPage RedirectToPayGradesPage() => _driver.RedirectToPayGrades();
    }
}