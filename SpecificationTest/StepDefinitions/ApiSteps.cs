﻿using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using TechTalk.SpecFlow;
using TfLData;

namespace SpecificationTest.StepDefinitions
{
    [Binding]
    public class ApiSteps
    {
        private HttpResponseMessage response;
        private string apiUrl;

        public ApiCommunicator communicator { get; set; }

        [Given(@"^the TFL API at (.*)$")]
        public void GivenTheTFLAPIAt(string apiUrl)
        {
            communicator = new ApiCommunicator(apiUrl);
            this.apiUrl = apiUrl;
        }

        [When(@"the API is queried")]
        public async System.Threading.Tasks.Task WhenTheAPIIsQueriedAsync()
        {
            HttpClient client = new HttpClient();
            response = await client.GetAsync(apiUrl);
            await communicator.GetAsync();
        }

        [Then(@"the API returns a successful response")]
        public void ThenTheApiReturnsASuccessfulResponse()
        {
            Assert.IsTrue(communicator.WasSuccessful());
        }

        [Then(@"I am redirected to the 401 Technical Error page")]
        public void ThenIAmRedirectedToThe401TechnicalErrorPage()
        {
            Assert.AreEqual("https://api.tfl.gov.uk/static-messages/401.html", response.RequestMessage.RequestUri.ToString());
        }
        [Then(@"the API returns (.*) records")]
        public async System.Threading.Tasks.Task ThenTheAPIReturnsRecordsAsync(int expectedCount)
        {
          
            List<object> BikePoints = await communicator.GetListOfItemsAsync();
            int actualCount = BikePoints.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }




    }
}
