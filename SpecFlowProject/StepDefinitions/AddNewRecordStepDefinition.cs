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
        private decimal _minSalary;
        private decimal _maxSalary;
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
        }

        [Given("the minimum salary is (.*) and the maximum salary is (.*)")]
        public void GivenTheSalaryInfoIs(decimal minSalary, decimal maxSalary)
        {
            _minSalary = minSalary;
            _maxSalary = maxSalary;
        }

        [When("the record is created")]
        public void WhenRecordIsCreated()
        {
            _payGradesPage = _dashBoardPage.RedirectToPayGradesPage();
            _gradeAdderPage = _payGradesPage.ClickAddButton();
            _currentGradePage = _gradeAdderPage.AddNewGrade(_name);
            _currentGradePage.AssignCurrency(_minSalary, _maxSalary);
        }

        [Then("the record should appear on the Pay Grades Page")]
        public void ThenTheResultShouldBe()
        {
            _payGradesPage = _currentGradePage.RedirectToPayGradesPage();
            _newRecord = _payGradesPage.FindRecord(_name);
            if (_newRecord == null)
            {
                Assert.Fail("The record could not be created");
            }
        }
    }
}