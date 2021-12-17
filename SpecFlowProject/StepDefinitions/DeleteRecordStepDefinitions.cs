using NUnit.Framework;
using OpenQA.Selenium;
using OrangeHRM.Pages;
using SpecFlow.Specs.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.StepDefinitions
{
    [Binding]
    public sealed class DeleteRecordStepDefinitions
    {
        private string _name;
        private PayGradesPage _payGradesPage;
        private IWebElement _recordToBeDeleted;

        public DeleteRecordStepDefinitions(BrowserDriver browserDriver)
        {
            _payGradesPage = new PayGradesPage(browserDriver.Current);
        }

        [Given("the record name to be deleted is (.*)")]
        public void GivenTheRecordNameIs(string name)
        {
            _name = name;
        }

        [When("the record is deleted")]
        public void WhenRecordIsDeleted()
        {
            _payGradesPage = _payGradesPage.DeleteRecord(_name);
        }

        [Then("the record should not appear on the pay grades page")]
        public void ThenTheResultShouldBe()
        {
            _recordToBeDeleted = _payGradesPage.FindRecord(_name);
            if (_recordToBeDeleted != null)
            {
                Assert.Fail("The record could not be deleted");
            }
        }
    }
}