using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
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
    public class CategoryThirdTest
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

        public CategoryThirdTest()
        {
            client = new HttpClient();
        }

        [Fact]
        public async Task DeleteCategory()
        {
            var find = await client.GetAsync(url);
            List<Category> lastOfFind = JsonConvert.DeserializeObject<List<Category>>(await find.Content.ReadAsStringAsync());
            HttpResponseMessage respose = await client.DeleteAsync(url + "/" + lastOfFind.Last().Id);

            Assert.Equal(HttpStatusCode.NoContent, respose.StatusCode);
        }
    }
}
