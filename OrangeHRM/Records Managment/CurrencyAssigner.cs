using OpenQA.Selenium;

namespace OrangeHRM.Records_Managment
{
    public sealed class CurrencyAssigner
    {
        private readonly By _add = By.Id("btnAddCurrency");
        private readonly IWebDriver _driver;
        private readonly By _maxSalary = By.Id("payGradeCurrency_maxSalary");
        private readonly By _minSalary = By.Id("payGradeCurrency_minSalary");
        private readonly By _name = By.Id("payGradeCurrency_currencyName");
        private readonly By _save = By.Id("btnSaveCurrency");

        public CurrencyAssigner(IWebDriver webDriver) => _driver = webDriver;

        public string CurrencyName { get; set; } = "UAH - Ukraine Hryvnia";

        public void Assign(decimal minSalary, decimal maxSalary)
        {
            _driver.FindElement(_add).Click();
            _driver.FindElement(_name).SendKeys(CurrencyName);
            _driver.FindElement(_minSalary).SendKeys(minSalary.ToString());
            _driver.FindElement(_maxSalary).SendKeys(maxSalary.ToString());
            _driver.FindElement(_save).Click();
        }
    }
}