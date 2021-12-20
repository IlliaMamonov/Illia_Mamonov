using DropBox;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class FileUploadingStepDefinitions
    {
        private readonly FileUploader _uploader;
        private readonly FolderContentReceiver _contentReceiver;

        public FileUploadingStepDefinitions()
        {
            _uploader = new FileUploader();
            _contentReceiver = new FolderContentReceiver();
        }

        [Given("the file is to be uploaded"), Scope(Scenario = "1 Upload a file")]
        public void GivenTheFile()
        {
            _uploader.BuildRequest();
        }

        

        [When("the file is uploaded"), Scope(Scenario  = "1 Upload a file")]
        public void WhenTheFileIsUploaded()
        {
            _uploader.Upload();
        }

        [Then("the uploading should be successful"), Scope(Scenario = "1 Upload a file")]
        public void ThenTheResponseShouldBeOk()
        {
            var responseStatusCode = _uploader.Response.StatusCode;
            IEnumerable<string> files = _contentReceiver.GetFiles();
            responseStatusCode.Should().Be(HttpStatusCode.OK);
            files.Should().Contain(RequestSender.FileName);
        }
    }
}