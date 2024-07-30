using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ConsoleBrowserAutomationVersion
{
    public static class NetflixPipeline
    {
        public static void OpenSite(IWebDriver webDriver)
        {
            webDriver.Navigate().GoToUrl("https://www.netflix.com/login");
        }

        public static void Login(IWebDriver webDriver)
        {
            Console.WriteLine("Para usar, deverá logar-se!");
            // Formulário dados
            Console.Write("Email/Número do cel: ");
            // string email = Console.ReadLine()!;
            string email = "cleb_oliv@yahoo.com.br";

            Console.Write("Senha: ");
            // string senha = Console.ReadLine()!;
            string senha = "Rebelcman*01";

            // Pega os elementos INPUT
            IWebElement emailInput = webDriver.FindElement(By.Id(":r0:"));
            IWebElement senhaInput = webDriver.FindElement(By.Id(":r3:"));
            // Passa os valores para os INPUTs
            emailInput.SendKeys(email);
            senhaInput.SendKeys(senha);

            GenericWebMethods.ClickButton(webDriver, "Entrar");
        }

        public static void EnterInPerfil(IWebDriver webDriver)
        {
            // List<IWebElement> elements = webDriver
            //     .FindElements(By.TagName("span"))
            //     .Where(e => !string.IsNullOrWhiteSpace(e.Text))
            //     .ToList();

            // for (int i = 0; i < elements.Count; i++)
            // {
            //     Console.WriteLine($"{elements[i].Text}");
            // }

            Console.Write("Selecionar perfil: ");
            string selectedPerfil = Console.ReadLine()!;

            GenericWebMethods.ClickButtonBySpan(webDriver, selectedPerfil);

            // Localiza a <div> com a classe 'parent-div'
            // var parentDiv = webDriver.FindElement(By.XPath("//div[@class='parent-div']"));

            // // Localiza todos os <a> dentro da <div> pai
            // var perfilButtons = parentDiv.FindElements(By.XPath(".//a"));

            // Console.WriteLine("-------| PERFIS |-------");
            // foreach (var item in perfilButtons)
            // {
            //     Console.WriteLine(item.Text);
            // }

            // Console.WriteLine(perfilButtons);
            // Console.WriteLine(perfilButtons.Count);
            // Console.Write("Selecionar perfil: ");
            // string selectedPerfil = Console.ReadLine()!;

            // IWebElement selectedPerfilBtn = webDriver.FindElement(By.XPath($"//a[span[contains(text(), '{selectedPerfil}')]]"));
            // selectedPerfilBtn.Click();
        }

        public static void SearchMedia(IWebDriver webDriver)
        {
            Console.Write("Nome do filme: ");
            string textToSearch = Console.ReadLine()!;
            string formattedToUrl = textToSearch.Replace(" ", "%20");
            webDriver.Navigate().GoToUrl($"https://www.netflix.com/search?q={formattedToUrl}");
            // IWebElement searchInput = webDriver.FindElement(By.XPath("//div[@class='searchBox']//input"));
            // IWebElement searchButton = webDriver.FindElement(By.ClassName("searchTab"));
            // searchButton.Click();

            // searchInput.SendKeys(textToSearch);
        }

        public static IWebElement GetMediaDirectly(IWebDriver webDriver)
        {
            IWebElement searchedMedia = webDriver.FindElement(By.TagName("a"));
            if (searchedMedia == null)
                return null!;
            else
                return searchedMedia;
            // Console.WriteLine("Rodando " + searchedMedia);
            // searchedMedia.Click();
        }

        public static void GetSearchedMedias(IWebDriver webDriver)
        {
            IWebElement searchedMedias = webDriver.FindElement(By.ClassName("ltr-gncw81"));
            Console.WriteLine(searchedMedias.Text);
        }

        public static void PlayMedia(IWebDriver webDriver, string name)
        {
            // Busca uma media que fizer parte da lista de filmes exibida, que contenha o NAME
            // var searchedMedia = webDriver
            // .FindElement(By.ClassName("ltr-1cjyscz"))
            // .FindElement(By.ClassName("fallback-text")).Text.Contains(name, StringComparison.InvariantCultureIgnoreCase);
            var searchedMedia = webDriver
            .FindElement(By.XPath($"//a[.//p[contains(text(), '{name}')]]"));

            Console.WriteLine(searchedMedia);
            // .FindElement(By.XPath("//div[@class='ltr-1cjyscz']"))

            
            // .Where(s => s.FindElement(By.ClassName("fallback-text")).Text.Contains("") );
        }
    }
}
