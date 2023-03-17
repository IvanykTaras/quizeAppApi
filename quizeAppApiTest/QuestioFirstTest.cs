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
    public class QuestioFirstTest
    {
        public HttpClient client;
        private readonly string url = "https://localhost:7185/api/Quize/question";
        public string constId = "64144f25ef6ebcd41b927fe2";
        public string constCategoryId = "64144f25ef6ebcd41b927fe1";
        public Question question = new Question()
        {
            ImageUrl = "some url",
            Title = "Title",
            TextOfQuestion = "Text question",
            TextOfAnswer = "Text answer"
        };


        public QuestioFirstTest()
        {
            client = new HttpClient();

            question.CategoryId = constCategoryId;
        }


        [Fact]
        public async Task GetAll()
        {

            var result = await client.GetAsync(url);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task Post()
        {
            question.Id = constId;
            string strCategory = JsonConvert.SerializeObject(question);
            StringContent content = new StringContent(strCategory, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, content);

            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        }
    }
}
