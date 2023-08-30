using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace APITestProject.Tests
{
    [TestFixture]
    public class APITest
    {
        private readonly RestClient client;

        public APITest()
        {
            client = new RestClient("https://api.tmsandbox.co.nz/v1"); // Initialize RestClient with base URL
        }

        [Test]
        public void YourTestMethod()
        {
            // Example usage of client in a test method
            var request = new RestRequest("/Categories/6327/Details.json?catalogue=false", Method.Get);
            
            // You can further customize the request as needed
            // request.AddHeader("Authorization", "Bearer YourAccessToken");
            // request.AddParameter("parameterName", "parameterValue");

            var response = client.Execute(request);

            // Your assertions and test logic here
            // For example, you can assert the response status code:
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            // You can also parse the response content as JSON if needed:
            // Deserialize the API response into YourResponseType
            var content = response.Content ?? string.Empty; // Ensure content is not null
            var jsonResponse = JsonConvert.DeserializeObject<ResponseType>(content);
            if (jsonResponse != null)
            { 

            // Assert on the acceptance criteria
            Assert.AreEqual("Carbon credits", jsonResponse.Name);
            Assert.IsTrue(jsonResponse.CanRelist);
            var galleryPromotion = jsonResponse.Promotions?.Find(p => p.Name == "Gallery");
            Assert.IsNotNull(galleryPromotion);
            StringAssert.Contains("Good position in category", galleryPromotion?.Description);
            }

        }
    }
}