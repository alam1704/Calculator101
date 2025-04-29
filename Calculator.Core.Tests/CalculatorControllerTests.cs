using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;

namespace Calculator.Core.Tests
{
    [TestClass]
    public class CalculatorControllerTests
    {
        private readonly HttpClient _client;

        public CalculatorControllerTests()
        {
            // Initialize the HttpClient with the base address of your API
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:44381") // Adjust the port as necessary
            };
        }

        //[TestMethod]
        //public async Task Calculate_ValidJsonRequest_CorrectResult()
        //{
        //    var json = "{\"Operation\":{\"ID\":0,\"Values\":[\"1\",\"2\",\"3\"]}}"; // Example JSON request
        //}
    }
}
