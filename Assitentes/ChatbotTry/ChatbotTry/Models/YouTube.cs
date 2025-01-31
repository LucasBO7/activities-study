using ChatbotTry.Models;
using System.Text.RegularExpressions;
using YTSearch.NET;

namespace ChatbotTry.Models
{
    public static class YouTube
    {
        // Roda uma mídia do youtube
        public static async Task<string> RunVideoByName(string prompt)
        {
            string searchingTextOnly = GetSearchName(prompt);

            var client = new YouTubeSearchClient();
            // Pesquisa no youtube e recebe os resultados
            var results = await client.SearchYoutubeVideoAsync(searchingTextOnly);

            // https://pt.stackoverflow.com/questions/148980/v%C3%ADdeo-n%C3%A3o-listado-no-youtube-problemas-para-abrir-usando-iframe
            string embedYtVideoUri = results.Results.FirstOrDefault()!.Url.Replace("watch?v=", "embed/");
            return embedYtVideoUri;
        }

        static string GetSearchName(string userInput)
        {
            string pattern = @"\b(musica|clipe|video)\b\s+(.*)";

            Match match = Regex.Match(userInput, pattern, RegexOptions.IgnoreCase);

            if (match.Success)
                return match.Groups[2].Value;
            else
                return null;
        }
    }
}
