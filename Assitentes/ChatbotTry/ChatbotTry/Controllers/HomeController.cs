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
using static ChatbotTry.Models.Method;

namespace ChatbotTry.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        // Palavras que indicam o pedido da data atual
        string[] dataAtual =
        {
            "dia atual",
            "dia e hoje",
            "data atual"
        };

        string[] playYoutubeVideo =
        {
            "quero ouvir",
            "musica",
            "video",
            "youtube",
            "clipe"
        };

        // Palavras que indicam o pedido de abrir um site
        string[] siteAbrir =
        {
            "site",
            "site do",
            "pagina",
            "pagina do",
        };

        // Palavras que indicam o pedido de clicar em algum botão do site
        string[] siteClickBotao =
        {
            "clique",
            "clica",
            "pressione",
            "pressiona",
            "va em",
            "va na ",
            "entre em"
        };

        // Palavras usadas para identificar perguntas
        string[] askingCommandWords =
        {
            "me de",
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

        string[] actionWebsiteCommandWords =
        {
            "abra",
            "abre",
            "abrir",
            "entre",
            "entra",
            "entrar",
            "va",
        };

        [HttpPost]
        public async Task<JsonResult> Salvar(string message_user)
        {
            string botReturn;

            ChatViewModel chatViewModel = new();

            #region Message_Formatation
            //string message_user = form["UserMessage"].ToString();
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

            // Data
            Intention.CreateNewIntention(intentionList, IntentionNames.Data, dataAtual, askingCommandWords, formattedMessage_user, $"Hoje é {DateTime.Now.ToLongDateString()}");

            // Abrir site
            Intention.CreateNewIntention(intentionList, IntentionNames.Website, siteAbrir, actionWebsiteCommandWords, formattedMessage_user, "Abrindo o site...", GenericWebMethods.OpenWebsite);

            // Clicar em botão - site
            Intention.CreateNewIntention(intentionList, IntentionNames.Website, siteClickBotao, formattedMessage_user, "Clicando no botão...", GenericWebMethods.ClickButton);

            // Video YouTube
            Intention.CreateNewIntention(intentionList, IntentionNames.Youtube, playYoutubeVideo, actionCommandWords, formattedMessage_user, $"Rodando vídeo do Youtube...", YouTube.RunVideoByName);

            // Verifica qual é a intenção selecionada
            Intention detectedIntention = intentionList.FirstOrDefault(i => i!.IsThis == true, null)!;


            if (detectedIntention == null)
                chatViewModel.BotResponse = "Nada identificado, realizando pesquisa...";
            else
            {
                // ATENÇÃO!!!!!!
                // ATENÇÃO!!!!!!
                // ATENÇÃO!!!!!!
                // ATENÇÃO!!!!!!
                // ATENÇÃO!!!!!!
                // ATENÇÃO!!!!!!
                // Depois podemos realizar uma troca, para que não seja necessário realizar este switch-case, realizando então a troca das propriedades para uma propriedade só para o recebimento do retorno dos métodos

                // Se o método for síncrono
                if (detectedIntention.CustomGenericFunction != null)
                    chatViewModel.FunctionResultReturn = detectedIntention.CustomGenericFunction(noAcentsMessage_user);
                else
                {
                    // Se o método for assíncrono
                    if (detectedIntention.CustomGenericFunctionAsync != null)
                        chatViewModel.FunctionResultReturn = await detectedIntention.CustomGenericFunctionAsync(noAcentsMessage_user);
                    else
                        // Se não houver método a ser executado
                        chatViewModel.BotResponse = detectedIntention.Response!;
                }


                //if (detectedIntention.CustomGenericFunction != null || detectedIntention.CustomGenericFunctionAsync != null)
                //{
                //    // Verifica se há alguma função para ser executada
                //    switch (detectedIntention.CustomGenericFunction!.Method.Name)
                //    {
                //        case nameof(YouTube.RunVideoByName):
                //            // Roda a função do método
                //            chatViewModel.YoutubeUri = await detectedIntention.CustomGenericFunctionAsync!(noAcentsMessage_user);
                //            chatViewModel.BotResponse = $"Reproduzindo {noAcentsMessage_user} no YouTube...";
                //            break;

                //        case nameof(GenericWebMethods.OpenWebsite):
                //            noAcentsMessage_user = GenericWebMethods.GetSiteSearchName(noAcentsMessage_user);
                //            chatViewModel.WebsiteUrl = detectedIntention.CustomGenericFunction(noAcentsMessage_user);
                //            chatViewModel.BotResponse = $"Abrindo o site {noAcentsMessage_user}...";
                //            break;

                //        case nameof(GenericWebMethods.ClickButton):
                //            noAcentsMessage_user = GenericWebMethods.GetButtonName(noAcentsMessage_user);
                //            chatViewModel.WebsiteUrl = detectedIntention.CustomGenericFunction(noAcentsMessage_user);
                //            chatViewModel.BotResponse = $"Clicando em {noAcentsMessage_user}...";
                //            break;

                //        default:
                //            chatViewModel = new()
                //            {
                //                BotResponse = $"Houve um erro na verificação do método: {result.CustomGenericFunction.Method.Name}",
                //                WebsiteUrl = null,
                //                YoutubeUri = null
                //            };
                //            break;
                //    }

                //}
                //else
                //    // Pega a resposta do bot
                //    chatViewModel.BotResponse = detectedIntention.Response!;
            }

            intentionList.Clear();

            return Json(chatViewModel);

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
