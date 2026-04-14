using Framework.API;
using Framework.Base;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Tests
{
    public class APITest : ApiBaseTest
    {
        [Test]
        public void Get_User_Details()
        {
            var api = new ApiHelper("https://free.mockerapi.com/mock/");

            var response = api.Get(
                "35311414-8a7f-44ec-8c81-441d20868239",
                headers: new Dictionary<string, string>
                {
            { "Accept", "application/json" }
                },
                bearerToken: "your_token_here"
            );

            api.ValidateResponse(response, HttpStatusCode.OK, "username");
        }
        [Test]
        public void Create_User()
        {
            var api = new ApiHelper("https://api.example.com");

            var body = new
            {
                username = "testuser",
                password = "12345"
            };

            var response = api.Post(
                "/users",
                body,
                headers: new Dictionary<string, string>
                {
            { "Custom-Header", "value123" }
                },
                username: "admin",
                password: "admin123"
            );

            api.ValidateResponse(response, HttpStatusCode.Created, "testuser");
        }
        [Test]
        public void Create_Product()
        {
            var api = new ApiHelper("https://api.example.com");

            var body = new
            {
                name = "Laptop",
                price = 1000
            };

            var response = api.Post(
                "/products",
                body,
                headers: new Dictionary<string, string>
                {
            { "env", "qa" }
                },
                bearerToken: "token123"
            );

            api.ValidateResponse(response, HttpStatusCode.OK, "Laptop");
        }
    }
}
