using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using Allure.Net.Commons;
using Newtonsoft.Json;

namespace Framework.API
{
    public class ApiHelper
    {
        private RestClient client;

        public ApiHelper(string baseUrl)
        {
            client = new RestClient(baseUrl);
        }

        // GET Request with bearertoken
        public RestResponse Get(
            string endpoint,
            Dictionary<string, string> headers = null,
            string bearerToken = null,
            string username = null,
            string password = null)
        {
            return AllureApi.Step($"GET Request → {endpoint}", () =>
            {
                var request = new RestRequest(endpoint, Method.Get);

                AddHeaders(request, headers);
                AddAuth(request, bearerToken, username, password);
                var response = client.Execute(request);
                LogToAllure("GET", endpoint, null, headers, response, bearerToken);

                return response;
            });
        }
        // GET Request
        public RestResponse Get(
            string endpoint,
            Dictionary<string, string> headers = null,
            string username = null,
            string password = null)
        {
            return AllureApi.Step($"GET Request → {endpoint}", () =>
            {
                var request = new RestRequest(endpoint, Method.Get);
                AddHeaders(request, headers);
                var response = client.Execute(request);
                LogToAllure("GET", endpoint, null, headers, response);
                return response;
            });
        }

        // POST Request
        public RestResponse Post(
            string endpoint,
            object body,
            Dictionary<string, string> headers = null,
            string bearerToken = null,
            string username = null,
            string password = null)
        {
            return AllureApi.Step($"POST Request → {endpoint}", () =>
            {
                var request = new RestRequest(endpoint, Method.Post);
                request.AddHeader("Content-Type", "application/json");
                AddHeaders(request, headers);
                AddAuth(request, bearerToken, username, password);
                request.AddJsonBody(body);
                var response = client.Execute(request);
                LogToAllure("POST", endpoint, body, headers, response, bearerToken);
                return response;
            });
        }

        // Add Headers
        private void AddHeaders(RestRequest request, Dictionary<string, string> headers)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }
        }

        // Authentication Type
        private void AddAuth(RestRequest request, string bearerToken, string username, string password)
        {
            if (!string.IsNullOrEmpty(bearerToken))
            {
                request.AddHeader("Authorization", $"Bearer {bearerToken}");
            }
            else if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{username}:{password}"));
                request.AddHeader("Authorization", $"Basic {base64}");
            }
        }

        // Allure Logging  
        private void LogToAllure(
         string method,
        string endpoint,
        object requestBody,
        Dictionary<string, string> headers,
        RestResponse response, string token=null)
        {
            AllureApi.Step("API Execution Details", () =>
            {
                AllureApi.Step($"Method: {method}");
                AllureApi.Step($"Endpoint: {endpoint}");
                if (requestBody != null)
                {
                    AllureApi.Step("Request Body", () =>
                    {
                        AllureApi.Step(
                            JsonConvert.SerializeObject(requestBody, Formatting.Indented)
                        );
                    });
                }
                if (headers != null)
                {
                    AllureApi.Step("Headers", () =>
                    {
                        AllureApi.Step(
                            JsonConvert.SerializeObject(headers, Formatting.Indented)
                        );
                    });
                }
                if (!string.IsNullOrEmpty(token))
                {
                    AllureApi.Step("Authorization: Token");
                }
                AllureApi.Step("Response Body", () =>
                {
                    AllureApi.Step(response.Content ?? "No Response");
                });
                AllureApi.Step($"Status Code: {response.StatusCode}");

                if (!string.IsNullOrEmpty(response.ErrorMessage))
                {
                    AllureApi.Step($"Error: {response.ErrorMessage}");
                }
            });
        }
        

        // Validation
        public void ValidateResponse(RestResponse response, HttpStatusCode expectedStatus, string expectedContent = null)
        {
            AllureApi.Step("Validate API Response", () =>
            {
                Assert.AreEqual(expectedStatus, response.StatusCode, "Status code mismatch");

                if (!string.IsNullOrEmpty(expectedContent))
                {
                    Assert.IsTrue(response.Content.Contains(expectedContent),
                        $"Expected content '{expectedContent}' not found");
                }
            });
        }
    }
}