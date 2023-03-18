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
    public class UserFirstTest
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


        public UserFirstTest()
        {

            client = new HttpClient();
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
            user.Id = constId;
            string strUser = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(strUser, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, content);

            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        }
    }
}
