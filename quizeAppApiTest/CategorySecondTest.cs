using Newtonsoft.Json;
using quizeAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace quizeAppApiTest
{
    
    public class CategorySecondTest 
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

        public CategorySecondTest() { 
            client = new HttpClient();
        }


        [Fact]
        public async Task GetCategory()
        {
            HttpResponseMessage result;
            result = await client.GetAsync(url + "/" + constId);

            //Category find = JsonConvert.DeserializeObject<Category>(await result.Content.ReadAsStringAsync());

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task PutCategory()
        {
            HttpResponseMessage getresult = await client.GetAsync(url + "/" + constId);

            Category find = JsonConvert.DeserializeObject<Category>(await getresult.Content.ReadAsStringAsync());

            find.Name = "dont change and delete";
            find.Description = "Change";

            var content = new StringContent(JsonConvert.SerializeObject(find), Encoding.UTF8, "application/json");



            HttpResponseMessage result = await client.PutAsync(url + "/" + constId, content);
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }
    }
}
