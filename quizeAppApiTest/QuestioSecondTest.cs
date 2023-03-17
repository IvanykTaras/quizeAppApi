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
    public class QuestioSecondTest
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

        public QuestioSecondTest()
        {
            client = new HttpClient();

            question.CategoryId = constCategoryId;
        }



        [Fact]
        public async Task GetQuestion()
        {
            HttpResponseMessage result;
            result = await client.GetAsync(url + "/" + constId);

            //Category find = JsonConvert.DeserializeObject<Category>(await result.Content.ReadAsStringAsync());

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task PutQuestion()
        {
            HttpResponseMessage getresult = await client.GetAsync(url + "/" + constId);

            Question find = JsonConvert.DeserializeObject<Question>(await getresult.Content.ReadAsStringAsync());

            find.TextOfQuestion = "question";
            find.TextOfAnswer = "answer";

            var content = new StringContent(JsonConvert.SerializeObject(find), Encoding.UTF8, "application/json");



            HttpResponseMessage result = await client.PutAsync(url + "/" + constId, content);
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }
    }
} 
