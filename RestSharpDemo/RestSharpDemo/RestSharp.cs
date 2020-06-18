using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Serialization.Json;
using RestSharpDemo.Model;

namespace RestSharpDemo
{
    [TestClass]
    public class RestSharp
    {
        [TestMethod]

        public void TestMethodGet()
        {

            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("tests/{id}", Method.GET);
            request.AddUrlSegment("id", 1);

            var response = client.Execute(request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);

            var result = output["marca"];

            response.StatusCode.Should().Be(200);

            Assert.IsTrue(result.Contains("Audi"));
        }

        [TestMethod]

        public void TestMethodPost()

        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("tests", Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(new MethodPost{ id = "2020", marca = "Audi", carro = "A8" });

            var response = client.Execute(request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);

            var result = output["id"];

            response.StatusCode.Should().Be(201);
            Assert.IsTrue(result.Contains("2020"));
        }
    }
}
