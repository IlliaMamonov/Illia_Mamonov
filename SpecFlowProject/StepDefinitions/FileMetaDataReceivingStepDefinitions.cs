using DropBox;
using NUnit.Framework;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class FileMetaDataReceivingStepDefinitions
    {
        private FileMetaDataReceiver _receiver;

        public FileMetaDataReceivingStepDefinitions() => _receiver = new FileMetaDataReceiver();

        [Given("the file to receive the meta data of"), Scope(Scenario = "2 Get the file meta data")]
        public void GivenTheFileToGetTheMetaData()
        {
            _receiver.BuildRequest();
        }

        [When("the meta data is received"), Scope(Scenario = "2 Get the file meta data")]
        public void WhenMetaDataIsReceived()
        {
            _receiver.GetMetaData();
        }

        [Then("the meta data should be received"), Scope(Scenario = "2 Get the file meta data")]
        public void ThenTheResponseShouldBeOk()
        {
            var responseStatusCode = _receiver.Response.StatusCode;
            if (responseStatusCode != HttpStatusCode.OK)
            {
                Assert.Fail("Unable to get the file meta data");
            }
        }
    }
}