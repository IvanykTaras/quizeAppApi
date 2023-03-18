using Newtonsoft.Json;
using quizeAppApi.Models;
using quizeAppApi.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace quizeAppApiTest
{
    public class UserSecondTest
    {

        public HttpClient client;
        private readonly string url = "https://localhost:7185/api/User";
        public string constId = "64144f25ef6ebcd41b927fe3";
        public User user = new User()
        {
            Name = "TestAdmin",
            Password = "password",
            Role = RoleOfUser.Admin
        };


        public UserSecondTest()
        {

            client = new HttpClient();
        }

        [Fact]
        public async Task GetUser()
        {
            HttpResponseMessage result;
            result = await client.GetAsync(url + "/" + constId);

            //Category find = JsonConvert.DeserializeObject<Category>(await result.Content.ReadAsStringAsync());

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task PutUser()
        {
            HttpResponseMessage getresult = await client.GetAsync(url + "/" + constId);

            User find = JsonConvert.DeserializeObject<User>(await getresult.Content.ReadAsStringAsync());

            find.Name = "dont change and delete";
            find.Password = "password";

            var content = new StringContent(JsonConvert.SerializeObject(find), Encoding.UTF8, "application/json");



            HttpResponseMessage result = await client.PutAsync(url + "/" + constId, content);
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }
    }
}
