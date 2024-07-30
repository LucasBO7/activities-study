using OpenQA.Selenium;

namespace BrowserAutomation.Models
{
    public class GenericWebMethods
    {
        public static void OpenWebsite(IWebDriver _webDriver, string websiteName)
        {
            // Formata em um url
            string websiteUrl = $"https://www.{websiteName}.com";

            // Navega para a url
            _webDriver.Navigate().GoToUrl(websiteUrl);
        }

        public static void ClickButton(IWebDriver _webDriver, string buttonContent)
        {
            try
            {
                // Busca um elemento A ou BUTTON por seu conteúdo
                IWebElement element = _webDriver.FindElement(
                    By.XPath(
                        $"//button[contains(text(), '{buttonContent}')] | //a[contains(text(), '{buttonContent}')]"
                    )
                );
                element.Click();

                Console.Beep(500, 500);
            }
            catch (NoSuchElementException exc)
            {
                Console.WriteLine("Erro: " + exc.Message);
                Console.Beep(800, 1500);
                // ClickButtonBySpan(_webDriver, buttonContent);
            }
        }

        /// <summary>
        /// Busca a lista de todos spans, pega seu index pelo texto(conteúdo) e clica-o
        /// </summary>
        /// <param name="_webDriver">Objeto WebDriver</param>
        /// <param name="clickedBtnContent">Texto do botão pesquisado a ser clicado</param>
        public static void ClickButtonBySpan(IWebDriver _webDriver, string clickedBtnContent)
        {
            // Busca um elemento span que contenha texto
            List<IWebElement> elements = _webDriver
                .FindElements(By.TagName("span"))
                .Where(e => !string.IsNullOrWhiteSpace(e.Text))
                .ToList();

            // for (int i = 0; i < elements.Count; i++)
            // {
            //     Console.WriteLine($"{elements[i].Text}");
            // }

            int indexOfClickedBtn;

            // Busca index do botão selecionado
            indexOfClickedBtn = GetElementIndex(elements, clickedBtnContent);

            // Se o botão spanx não foi encontrado
            if (indexOfClickedBtn == -1)
            {
                // Mensagem de erro
                Console.WriteLine(
                    "ERRO! Insira algum texto que exista dentre as opções possíveis!"
                );
                Console.Beep(800, 1500);

                // Inserção de novo valor
                // Console.Write("Insira o botão que deseja clicar: ");
                // clickedBtnContent = Console.ReadLine()!;
            }
            else
                // Clica no botão associado ao span
                elements[indexOfClickedBtn].Click();
            // do
            // {
            //     // Busca index do botão selecionado
            //     indexOfClickedBtn = GetElementIndex(elements, clickedBtnContent);

            //     // Se o botão spanx não foi encontrado
            //     if (indexOfClickedBtn == -1)
            //     {
            //         // Mensagem de erro
            //         Console.BackgroundColor = ConsoleColor.Red;
            //         Console.WriteLine(
            //             "ERRO! Insira algum texto que exista dentre as opções possíveis!"
            //         );
            //         Console.ResetColor();
            //         Console.WriteLine();

            //         // Inserção de novo valor
            //         // Console.Write("Insira o botão que deseja clicar: ");
            //         // clickedBtnContent = Console.ReadLine()!;
            //     }
            // } while (indexOfClickedBtn == -1);

            // Clica no botão associado ao span
            // elements[indexOfClickedBtn].Click();
        }

        public static int GetElementIndex(List<IWebElement> elements, string searchingText)
        {
            return elements.FindIndex(
                0,
                elements.Count,
                e => e.Text.Contains(searchingText, StringComparison.CurrentCultureIgnoreCase)
            );
        }
    }
}
