using OpenQA.Selenium;

namespace OrangeHRM.Pages
{
    public sealed partial class CurrentGradePage : IPage
    {
        internal sealed partial class CurrencyAssigner
        {
            private readonly IWebDriver _driver;
            private readonly By _maxSalary = By.Id("payGradeCurrency_maxSalary");
            private readonly By _minSalary = By.Id("payGradeCurrency_minSalary");
            private readonly By _name = By.Id("payGradeCurrency_currencyName");
            private readonly By _save = By.Id("btnSaveCurrency");

            public CurrencyAssigner(IWebDriver webDriver) => _driver = webDriver;

            public string CurrencyName { get; set; } = "UAH - Ukraine Hryvnia";

            public void AssignCurrency(decimal minSalary, decimal maxSalary)
            {
                _driver.FindElement(_name).SendKeys(CurrencyName);
                _driver.FindElement(_minSalary).SendKeys(minSalary.ToString());
                _driver.FindElement(_maxSalary).SendKeys(maxSalary.ToString());
                _driver.FindElement(_save).Click();
            }
        }
    }
}