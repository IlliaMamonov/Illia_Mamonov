using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace OrangeHRM.Pages
{
    public sealed partial class CurrentGradePage : IPage
    {
        private readonly By _add = By.Id("btnAddCurrency");
        private  readonly IWebDriver _driver;
        private int? _id = null;

        public CurrentGradePage(IWebDriver webDriver) => _driver = webDriver;

        public IWebDriver Driver => _driver;

        public int ID
        {
            get
            {
                if (_id != null)
                {
                    return (int)_id;
                }
                var currentUrl = _driver.Url;
                var regex = @"\d";
                var matches = Regex.Matches(currentUrl, regex);
                var idString = "";
                foreach (Match match in matches)
                {
                    idString += match.Value;
                }
                int.TryParse(idString, out var id);

                return id;
            }
        }

        public CurrentGradePage AssignCurrency(decimal minSalary, decimal maxSalary)
        {
            _driver.FindElement(_add).Click();
            var assigner = new CurrencyAssigner(_driver);
            assigner.AssignCurrency(minSalary, maxSalary);
            return this;
        }

        public PayGradesPage RedirectToPayGradesPage() => _driver.RedirectToPayGrades();

        internal sealed partial class CurrencyAssigner
        { };
    }
}