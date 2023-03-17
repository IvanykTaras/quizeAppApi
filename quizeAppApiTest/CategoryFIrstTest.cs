using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Newtonsoft.Json;
using quizeAppApi.Models;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;

namespace quizeAppApiTest
{
    public class CategoryFIrstTest
    {
        public HttpClient client;
        private readonly string url = "https://localhost:7185/api/Quize/category";
        public string constId = "64144f25ef6ebcd41b927fe1";
        public Category category = new Category()
        {
            Name = "UnitTest",
            Description = "UnitDescription",
            ImageUrl = "unit Url"
        };


        public CategoryFIrstTest() { 
        
            client = new HttpClient();
        }


        [Fact]
        public async Task GetAll()
        {
            
            var result =  await client.GetAsync(url);
            
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task GetAllCategoryQuestions()
        {
            var result = await client.GetAsync(url+"/question/"+constId);

            Assert.Equal(HttpStatusCode.OK,result.StatusCode);
        }

        [Fact]
        public async Task Post()
        {
            category.Id = constId;
            string strCategory = JsonConvert.SerializeObject(category);
            StringContent content = new StringContent(strCategory, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, content);

            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        }
    }
}