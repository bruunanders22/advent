using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAPIClient
{

    class WebserviceTools
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<Result> CallAddWebservice(double n, double m)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync($"https://aspnetrest2022.herokuapp.com/add?addParams=({n},{m})");
            var result = await JsonSerializer.DeserializeAsync<Result>(await streamTask);
            return result;
        }
    }


    class Test
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestAdd()
        {
            var result = await WebserviceTools.CallAddWebservice(10.0, 20.0);
            Assert.AreEqual(30.0, result.sum);
        }


    }

}
