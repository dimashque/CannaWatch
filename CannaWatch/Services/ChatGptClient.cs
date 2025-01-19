using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CannaWatch.Services
{
    public  class ChatGptClient
    {
        private readonly HttpClient _httpClient;

        public ChatGptClient(string apiKey)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        }

      /*  public async Task<string> GetPlantInfoAsync(string plantDetails)
        {
            var requestBody = new
            {
                model = "gpt-3.5-turbo", // Specify the model you want to use
                messages = new[]
                {
                    new { role = "user", content = $"Tell me about {plantDetails} cannabis plant." }
                },
                max_tokens = 100 // Adjust token limit as needed
            };

            var json = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            dynamic responseObject = JsonConvert.DeserializeObject(jsonResponse);
            return responseObject.choices[0].message.content.ToString();
        } */

        public async Task<string> GetPlantInfoAsync(string input)
        {
            var jsonContent = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
            new { role = "user", content = input }
        },
                temperature = 0.7
            };

            var requestBody = new StringContent(JsonConvert.SerializeObject(jsonContent), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", requestBody);
                response.EnsureSuccessStatusCode(); // Throws an exception if the response status is not successful

                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent; // Ensure to parse this response for actual content
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}"); // Check the inner exception for more details
                }
                throw; // Re-throw the exception or handle it as needed
            }
        }

    }
}
