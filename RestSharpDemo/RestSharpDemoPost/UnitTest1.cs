using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace RestSharpDemoPost
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("tests", Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(new Post())
        }
    }
}
