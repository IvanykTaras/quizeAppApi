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
    public class QuestioThirdTest
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

        public QuestioThirdTest()
        {
            client = new HttpClient();

            question.CategoryId = constCategoryId;
        }


        [Fact]
        public async Task DeleteQuestion()
        {
            var find = await client.GetAsync(url);
            List<Question> lastOfFind = JsonConvert.DeserializeObject<List<Question>>(await find.Content.ReadAsStringAsync());
            HttpResponseMessage respose = await client.DeleteAsync(url + "/" + lastOfFind.Last().Id);

            Assert.Equal(HttpStatusCode.NoContent, respose.StatusCode);
        }

    }
}
