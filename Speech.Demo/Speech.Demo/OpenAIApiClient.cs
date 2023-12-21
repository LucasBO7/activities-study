using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text;
using static Speech.Demo.OpenAIApiClient;

namespace Speech.Demo
{
    internal class OpenAIApiClient
    {

        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OpenAIApiClient(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.openai.com/v1/chat/completions");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        }

        public class GptRequest
        {
            public string id { get; set; }
            public string Object { get; set; }
            public string created { get; set; }
            public string model { get; set; }
            public List<Choice> choices { get; set; }
            public Usage usage { get; set; }
        }

        public class Usage
        {
            public int prompt_tokens { get; set; }
            public int completion_tokens { get; set; }
            public int total_tokens { get; set; }
        }

        public class Choice
        {
            public string text { get; set; }
            public int index { get; set; }
            public string logprobs { get; set; }
            public string finish_reason { get; set; }
        }


        public class Message
        {
            public string role { get; set; }
            public string content { get; set; }
        }

        public class RequestBody
        {
            public string model { get; set; }
            public Message[] messages { get; set; } = new Message[2];
            public int temperature { get; set; }
            public int max_tokens { get; set; }
        }


        public async Task<string> SendPrompt(string _prompt, string _model)
        {
            /*
            var requestBody = new
            {
                prompt = _prompt,
                model = _model,
                max_tokens = 150,
                temperature = 1
            };

            var httpResponse = await _httpClient.PostAsJsonAsync("completions", requestBody);
            httpResponse.EnsureSuccessStatusCode();
            await Console.Out.WriteLineAsync("Status: " + httpResponse.StatusCode);

            // Pegar o retorno do request da API no formato de string
            var requestResponse = await httpResponse.Content.ReadAsStringAsync();

            // Converter o retorno da request string (porém no formato JSON) em um objeto com 
            var data = JsonConvert.DeserializeObject<dynamic>(requestResponse);

            return data.choices[0].text;*/
            /*
            var requestBody = new
            {
                model = _model,
                messages = new Message
                {
                    role = "user",
                    content = _prompt
                },
                temperature = 1,
                max_tokens = 150,
            };*/

            RequestBody requestBody = new()
            {
                model = _model,
                temperature = 1,
                max_tokens = 150,
            };
            requestBody.messages[1] = new Message
            {
                role = "user",
                content = _prompt
            };

            var json = JsonConvert.SerializeObject(requestBody);

            var httpResponse = await _httpClient.PostAsync(_httpClient.BaseAddress, new StringContent(json, Encoding.UTF8, "application/json"));
            var requestStringResponse = await httpResponse.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<dynamic>(requestStringResponse);
            Console.WriteLine("Retorno aí: " + response);
            return requestStringResponse;
        }
    }
}