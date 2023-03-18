using quizeAppApi.Models.Enum;
using quizeAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace quizeAppApiTest
{
    public class UserThirdTest
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


        public UserThirdTest()
        {

            client = new HttpClient();
        }


        [Fact]
        public async Task DeleteUser()
        {
            var find = await client.GetAsync(url);
            List<User> lastOfFind = JsonConvert.DeserializeObject<List<User>>(await find.Content.ReadAsStringAsync());
            HttpResponseMessage respose = await client.DeleteAsync(url + "/" + lastOfFind.Last().Id);

            Assert.Equal(HttpStatusCode.NoContent, respose.StatusCode);
        }
    }
}
