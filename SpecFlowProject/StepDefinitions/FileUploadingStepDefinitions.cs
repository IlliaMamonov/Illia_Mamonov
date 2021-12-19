using DropBox;
using NUnit.Framework;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class FileUploadingStepDefinitions
    {
        private FileUploader _uploader;

        public FileUploadingStepDefinitions() => _uploader = new FileUploader();

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
            if (responseStatusCode != HttpStatusCode.OK)
            {
                Assert.Fail("Unable to upload the file");
            }
        }
    }
}