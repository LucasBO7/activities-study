using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using OpenAI_API;
using RestSharp;
using RestSharp.Authenticators.OAuth2;
using static System.Net.Mime.MediaTypeNames;

namespace ChatbotTry.Models
{
    public static class ChatGpt
    {
        private static readonly string _apiKey = "sk-proj-bTiAvphhgxKjJYYUSOSFT3BlbkFJWYwRrnuZjFJTek9sub9m";

        public static async Task<string> SendRequestToChatGptAsync(string prompt)
        {
            var api = new OpenAI_API.OpenAIAPI(new APIAuthentication(_apiKey));
            var chat = api.Chat.CreateConversation();
            chat.Model = "gpt-3.5-turbo";

            chat.AppendUserInput($"Fale somente o que o usuário deseja pesquisar (entidade) na frase a seguir. Não fale mais nada além do nome somente: {prompt}");

            string response = await chat.GetResponseFromChatbotAsync();

            return response;

            //var result = await api.Chat.CreateChatCompletionAsync($"Fale somente o que o usuário deseja pesquisar (entidade) na frase a seguir. Não fale mais nada além do nome somente: {prompt}");

            //return result.Choices[0].Message.TextContent;

            /*
            var clientOptions = new RestClientOptions("https://api.openai.com")
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(_apiKey, "Bearer")
            };
            var client = new RestClient(clientOptions);

            var request = new RestRequest("/v1/engines/gpt-3.5-turbo", RestSharp.Method.Post);
            request.AddJsonBody(new { prompt = $"Fale somente o que o usuário deseja pesquisar (entidade) na frase a seguir. Não fale mais nada além do nome somente: {prompt}", max_tokens = 1000 });

            var response = await client.ExecuteAsync(request);
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content!)!;

            // Verifica se jsonResponse e jsonResponse.choices não são null
            if (jsonResponse != null && jsonResponse.choices != null && jsonResponse.choices.Count > 0)
            {
                return jsonResponse.choices[0].text;
            }
            else
            {
                // Retorna uma mensagem de erro ou lida com a situação de maneira adequada
                return "Erro ao obter resposta do GPT-Chat.";
            }

            //return jsonResponse.choices[0].text;

            */
        }
    }
}
