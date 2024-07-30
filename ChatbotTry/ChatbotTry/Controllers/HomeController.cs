using ChatbotTry.Models;
using ChatbotTry.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ChatbotTry.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //IWebDriver webDriver = new ChromeDriver();
            //TempData["WebDriver"] = webDriver;
            //TempData.Keep("WebDriver");
        }

        public IActionResult Index()
        {
            return View();
        }

        // Palavras que indicam saudação
        string[] saudacaoWords =
        {
            "bom dia",
            "boa tarde",
            "boa noite",
            "salve",
            "ola",
            "oi",
            "eai",
            "como vai",
            "alo",
            "fala"
        };

        // Palavras que indicam despedida
        string[] despedidaWords =
        {
            "tchau",
            "falou",
            "valeu",
            "ate mais",
            "obrigado"
        };

        // Palavras que indicam o pedido do horário
        string[] horarioAtual =
        {
            "que horas sao",
            "horario atual",
            "que horas e agora"
        };

        string[] playYoutubeVideo =
        {
            "quero ouvir",
            "musica",
            "video",
            "youtube",
            "clipe"
        };

        // Palavras usadas para identificar perguntas
        string[] askingCommandWords =
        {
            "mede",
            "me diga",
            "me fale",
            "me passe",
            "gostaria de saber",
            "quero saber",
            "qual",
            "que"
        };

        string[] actionCommandWords =
        {
            "toque",
            "coloque",
            "colocasse",
            "coloca",
            "toca",
            "mostre",
            "de um play",
            "quero",
            "reproduza"
        };



        public async Task<ChatViewModel> Salvar(IFormCollection form)
        {
            string botReturn;

            ChatViewModel chatViewModel = new();

            #region Message_Formatation
            string message_user = form["UserMessage"].ToString();
            // Texto em minusculo
            string formattedMessage_user = message_user.ToLower();
            // Retira acentos
            string noAcentsMessage_user = StringExtension.RemoveDiacritics(formattedMessage_user);
            // Retira espacos (incluindo tab)
            //formattedMessage_user = Regex.Replace(formattedMessage_user, @"\s", "");
            formattedMessage_user = new string(noAcentsMessage_user.Where(c => !char.IsPunctuation(c)).ToArray());
            #endregion

            List<Intention> intentionList = new();

            // Saudação
            Intention.CreateNewIntention(intentionList, IntentionNames.Saudacao, saudacaoWords, formattedMessage_user, "Pois não mestre");

            // Despedida
            Intention.CreateNewIntention(intentionList, IntentionNames.Despedida, despedidaWords, formattedMessage_user, "Até mestre");

            // Horário
            Intention.CreateNewIntention(intentionList, IntentionNames.Horario, horarioAtual, askingCommandWords, formattedMessage_user, $"Agora são {DateTime.Now.ToLongTimeString()}");

            // Video YouTube
            Intention.CreateNewIntention(intentionList, IntentionNames.Youtube, playYoutubeVideo, actionCommandWords, formattedMessage_user, $"Rodando vídeo do Youtube...", YouTube.RunVideoByName);

            // Verifica qual é a intenção selecionada
            var result = intentionList.FirstOrDefault(i => i.IsThis == true, null);


            if (result == null)
                chatViewModel.BotResponse = "Nada identificado, realizando pesquisa...";
            else
            {
                // Verifica se há alguma função para ser executada
                if (result.CustomGenericFunction != null)
                    // Roda a função do método
                    chatViewModel = new()
                    {
                        YoutubeUri = await result.CustomGenericFunction(noAcentsMessage_user),
                        BotResponse = $"Reproduzindo {noAcentsMessage_user} no YouTube..."
                    };
                else
                    // Pega a resposta do bot
                    chatViewModel.BotResponse = result.Response!;
            }

            intentionList.Clear();

            return chatViewModel;

            //return View("Index", chatViewModel);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                }
            );
        }
    }
}
