using NUnit.Framework;
using OpenQA.Selenium;
using OrangeHRM.Pages;
using SpecFlow.Specs.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.StepDefinitions
{
    [Binding]
    public sealed class AddNewRecordStepDefinition
    {
        private CurrentGradePage _currentGradePage;
        private DashBoardPage _dashBoardPage;
        private GradeAdderPage _gradeAdderPage;
        private string _name;
        private IWebElement _newRecord;
        private PayGradesPage _payGradesPage;

        public AddNewRecordStepDefinition(BrowserDriver browserDriver)
        {
            _dashBoardPage = new DashBoardPage(browserDriver.Current);
        }

        [Given("the name of the record to be created is (.*)")]
        public void GivenTheGradeNameIs(string name)
        {
            _name = name;
            _payGradesPage = _dashBoardPage.RedirectToPayGradesPage();
            _gradeAdderPage = _payGradesPage.ClickAddButton();
            _currentGradePage = _gradeAdderPage.AddNewGrade(_name);
        }

        [Given("the minimum salary is (.*) and the maximum salary is (.*)")]
        public void GivenTheSalaryInfoIs(decimal minSalary, decimal maxSalary)
        {
            _currentGradePage.AssignCurrency(minSalary, maxSalary);
        }

        [When("the record is being looked for")]
        public void WhenRecordIsLookedFor()
        {
            _payGradesPage = _currentGradePage.RedirectToPayGradesPage();
            _newRecord = _payGradesPage.FindRecord(_name);
        }

        [Then("the record should be found")]
        public void ThenTheResultShouldBe()
        {
            if (_newRecord == null)
            {
                Assert.Fail("The record could not be created");
            }
        }
    }
}