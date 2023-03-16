using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Newtonsoft.Json;
using quizeAppApi.Models;
using System.Net;
using System.Text;

namespace quizeAppApiTest
{
    public class CategoryCollectionTest
    {
        private readonly string url = "https://localhost:7185/api/Quize";
        public Category category = new Category()
        {
            Name = "UnitTest",
            Description = "UnitDescription",
            ImageUrl = "unit Url"
        };


        [Fact]
        public void GetAll()
        {
            HttpClient client = new HttpClient();
            
            var result = client.GetAsync(url).Result;
            
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void Put()
        {
            HttpClient client = new HttpClient();

            string strCategory = JsonConvert.SerializeObject(category);
            StringContent content = new StringContent(strCategory, Encoding.UTF8, "application/json");
            var result = client.PostAsync(url, content).Result;

            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        }
    }
}