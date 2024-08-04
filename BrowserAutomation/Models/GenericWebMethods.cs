using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;

namespace BrowserAutomation.Models
{
    public class GenericWebMethods
    {
        public static bool OpenWebsite(IWebDriver _webDriver, string websiteName)
        {
            try
            {
                // Formata em um url
                string websiteUrl = $"https://www.{websiteName}.com";

                // Navega para a url
                _webDriver.Navigate().GoToUrl(websiteUrl);
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }

        public static int ClickButton(IWebDriver _webDriver, string buttonContent)
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

                return 1;

                //Console.Beep(500, 500);
            }
            catch (NoSuchElementException exc)
            {
                Console.WriteLine("Erro: " + exc.Message);
                //Console.Beep(800, 1500);
                return ClickButtonBySpan(_webDriver, buttonContent);
            }
        }

        /// <summary>
        /// Busca a lista de todos spans, pega seu index pelo texto(conteúdo) e clica-o
        /// </summary>
        /// <param name="_webDriver">Objeto WebDriver</param>
        /// <param name="clickedBtnContent">Texto do botão pesquisado a ser clicado</param>
        public static int ClickButtonBySpan(IWebDriver _webDriver, string clickedBtnContent)
        {
            // Busca os elementos span que contenham o texto
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

            // Se o botão span não foi encontrado
            if (indexOfClickedBtn == -1)
            {
                // Mensagem de erro
                Console.WriteLine(
                    "ERRO! Insira algum texto que exista dentre as opções possíveis!"
                );
                //Console.Beep(800, 1500);
                return 0;

                // Inserção de novo valor
                // Console.Write("Insira o botão que deseja clicar: ");
                // clickedBtnContent = Console.ReadLine()!;
            }
            else
            {
                // Clica no botão associado ao span
                elements[indexOfClickedBtn].Click();
                return 2;
            }
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

        public static bool InsertInputValue(IWebDriver _webDriver, string selectedOptionByName, string newInputValue)
        {
            // Quantidade de inputs na página
            int inputsCount = _webDriver.FindElements(By.TagName("input")).Count;
            // Inicialização das listas de inputs e spans
            List<IWebElement> inputs = [];
            List<IWebElement> labels = [];

            // Atribuição dos elementos às listas
            for (int i = 0; i < inputsCount; i++)
            {
                inputs.Add(_webDriver.FindElements(By.TagName("input"))[i]);
                labels.Add(_webDriver.FindElements(By.TagName("label"))[i]);
            }

            // Imprime os inputs da página juntamente ao seu label e valor
            Console.WriteLine("___________________________________");
            for (int item = 0; item < inputs.Count; item++)
            {
                // Exemplo
                // email: valor
                Console.WriteLine($"{labels[item].Text}: {inputs[item].GetAttribute("value")}");
            }
            Console.WriteLine("___________________________________");

            // Busca o valor que contiver o texto escrito no input selectedOptionByName ignorando o CASE
            int labelIndexSearched = GetElementIndex(labels, selectedOptionByName);

            // Se não encontrar o input/label, pede um novo valor, no caso do web, deve retornar false para receber um novo valor
            if (labelIndexSearched == -1)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("ERRO! Insira algum texto que exista dentre as opções possíveis!");
                Console.ResetColor();
                Console.WriteLine();
                return false;
            }

            inputs[labelIndexSearched].Clear(); // Limpa o antigo valor do input (se houver)

            inputs[labelIndexSearched].SendKeys(newInputValue); // Envia o novo valor ao input
            return true;
        }

        public static void ScrollWindow(IWebDriver _webDriver, string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;

            js.ExecuteScript($"window.scrollBy(0, {value}400)");
        }

    }
}