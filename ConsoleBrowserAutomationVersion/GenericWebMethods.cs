using OpenQA.Selenium;

namespace ConsoleBrowserAutomationVersion
{
    public static class GenericWebMethods
    {
        public static string OpenWebsite(IWebDriver _webDriver, string websiteName)
        {
            // Formata em um url
            string websiteUrl = $"https://www.{websiteName}.com";

            // Navega para a url
            _webDriver.Navigate().GoToUrl(websiteUrl);
            return websiteUrl;
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
            }
            catch (NoSuchElementException)
            {
                ClickButtonBySpan(_webDriver, buttonContent);
            }            
        }

        public static void ClickButtonBySpan(IWebDriver _webDriver, string clickedBtnContent)
        {
            // Busca um elemento span que contenha texto
            List<IWebElement> elements = _webDriver.FindElements(
                By.TagName("span")
            ).Where(e => !string.IsNullOrWhiteSpace(e.Text)).ToList();

            // for (int i = 0; i < elements.Count; i++)
            // {
            //     Console.WriteLine($"{elements[i].Text}");
            // }

            int indexOfClickedBtn;
            do
            {
                // Busca index do botão selecionado
                indexOfClickedBtn = GetElementIndex(elements, clickedBtnContent);

                // Verificação
                if (indexOfClickedBtn == -1){
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO! Insira algum texto que exista dentre as opções possíveis!");
                    Console.ResetColor();
                    Console.WriteLine();

                    Console.Write("Insira o botão que deseja clicar: ");
                    clickedBtnContent = Console.ReadLine()!;
                }
            } while (indexOfClickedBtn == -1);

            // Clica no botão associado ao span
            elements[indexOfClickedBtn].Click();
        }



        public static void InsertInputValueInForm(IWebDriver _webDriver)
        {
            IWebElement form = _webDriver.FindElement(By.TagName("form"));
            // Console.WriteLine(form.Text);

            int inputsCount = form.FindElements(By.TagName("input")).Count;
            List<IWebElement> inputs = [];
            List<IWebElement> span = [];

            for (int i = 0; i < inputsCount; i++)
            {
                inputs.Add(form.FindElements(By.TagName("input"))[i]);
                span.Add(form.FindElements(By.TagName("label"))[i]);
            }

            Console.WriteLine("_____SPANs LIST______");
            for (int x = 0; x < span.Count; x++)
            {
                Console.WriteLine(span[x].Text);
                inputs[x].SendKeys(Console.ReadLine());
            }
        }

        public static void InsertInputValue(IWebDriver _webDriver)
        {
            // Quantidade de inputs na página
            int inputsCount = _webDriver.FindElements(By.TagName("input")).Count;
            // Inicialização das listas de inputs e spans
            List<IWebElement> inputs = [];
            List<IWebElement> span = [];

            // Atribuição dos elementos às listas
            for (int i = 0; i < inputsCount; i++)
            {
                inputs.Add(_webDriver.FindElements(By.TagName("input"))[i]);
                span.Add(_webDriver.FindElements(By.TagName("label"))[i]);
            }

            string selectedOptionByName;
            do
            {
                Console.Clear();
                // Imprime os inputs da página juntamente ao seu span e valor
                Console.WriteLine("___________________________________");
                for (int item = 0; item < inputs.Count; item++)
                {
                    // Exemplo
                    // Email: valor
                    Console.WriteLine($"{span[item].Text}: {inputs[item].GetAttribute("value")}");
                }
                Console.WriteLine("___________________________________");
                
                int spanIndexSearched;
                // Busca input por nome
                do
                {
                    // Pega o nome do input que deseja inserir o valor
                    Console.Write("Insira qual input deseja preencher: ");
                    selectedOptionByName = Console.ReadLine()!.ToLower();

                    // Busca o valor que contiver o texto escrito no input anterior ignorando o CASE
                    // spanIndexSearched = span.FindIndex(0, span.Count, s => s.Text.Contains(selectedOptionByName, StringComparison.CurrentCultureIgnoreCase));
                    spanIndexSearched = GetElementIndex(span, selectedOptionByName);

                    if (spanIndexSearched == -1 && selectedOptionByName != "jarvissair"){
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERRO! Insira algum texto que exista dentre as opções possíveis!");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                } while (spanIndexSearched == -1 && selectedOptionByName != "jarvissair");
                Console.Clear();
                
                if (selectedOptionByName != "jarvissair"){
                    // Insere o valor
                    inputs[spanIndexSearched].Clear(); // Limpa o valor anterior
                    Console.Write($"{span[spanIndexSearched].Text}: ");
                    inputs[spanIndexSearched].SendKeys(Console.ReadLine());
                }
            } while (selectedOptionByName != "jarvissair");
        }

        public static int GetElementIndex(List<IWebElement> elements, string searchingText){
            return elements.FindIndex(0, elements.Count, e => e.Text.Contains(searchingText, StringComparison.CurrentCultureIgnoreCase));
        }



        public static void ScrollWindow(IWebDriver _webDriver, string value){
            IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;

            js.ExecuteScript($"window.scrollBy(0, {value}400)");
        }



        // public static void InsertInputValue(IWebDriver _webDriver)
        // {
        //     int inputsCount = _webDriver.FindElements(By.TagName("input")).Count;
        //     List<IWebElement> inputs = [];
        //     List<IWebElement> span = [];

        //     for (int i = 0; i < inputsCount; i++)
        //     {
        //         inputs.Add(_webDriver.FindElements(By.TagName("input"))[i]);
        //         span.Add(_webDriver.FindElements(By.TagName("label"))[i]);
        //     }

        //     int inputTxt;
        //     string inputMenu;
        //     do
        //     {
        //         Console.Clear();
        //         // Imprime os inputs detectados juntamente ao seu span e valor
        //         Console.WriteLine("___________________________________");
        //         for (int item = 0; item < inputs.Count; item++)
        //         {
        //             // Exemplo
        //             // [0] Email: valor
        //             Console.WriteLine($"[{item}] {span[item].Text}: {inputs[item].GetAttribute("value")}");
        //         }
        //         Console.WriteLine("___________________________________");
                
        //         // Pega a posição
        //         Console.Write("Insira qual input deseja preencher:");
        //         inputTxt = int.Parse(Console.ReadLine()!);

        //         // Insere o valor
        //         inputs[inputTxt].Clear(); // Limpa o valor anterior
        //         Console.Write($"{span[inputTxt].Text}: ");
        //         inputs[inputTxt].SendKeys(Console.ReadLine());

        //         Console.WriteLine();
        //         Console.Write("Deseja voltar para o menu?: ");
        //         inputMenu = Console.ReadLine()!;
        //     } while (inputMenu != "s" && inputMenu != "sim");
        // }

        public static void QuitSession(IWebDriver _webDriver)
        {
            _webDriver.Close();
        }
    }
}
