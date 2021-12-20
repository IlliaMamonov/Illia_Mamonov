using DropBox;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class FileDeletingStepDefinitions
    {
        private FileDeleter _deleter;

        private readonly FolderContentReceiver _contentReceiver;

        public FileDeletingStepDefinitions()
        {
            _deleter = new FileDeleter();
            _contentReceiver = new FolderContentReceiver();
        }

        [Given("the file to be deleted"), Scope(Scenario = "3 Delete the file")]
        public void GivenTheFileToBeDeleted()
        {
            _deleter.BuildRequest();
        }

        [When("the file is deleted"), Scope(Scenario = "3 Delete the file")]
        public void WhenFileIsDeleted()
        {
            _deleter.Delete();
        }

        [Then("the deleting should be successful"), Scope(Scenario = "3 Delete the file")]
        public void ThenTheResponseShouldBeOk()
        {
            var responseStatusCode = _deleter.Response.StatusCode;
            IEnumerable<string> files = _contentReceiver.GetFiles();
            responseStatusCode.Should().Be(HttpStatusCode.OK);
            files.Should().NotContain(RequestSender.FileName);
        }
    }
}
