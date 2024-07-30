// See https://aka.ms/new-console-template for more information
using ConsoleBrowserAutomationVersion;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
/*
#region  Netflix_Pipeline_Version
IWebDriver webDriver = new ChromeDriver();
NetflixPipeline.OpenSite(webDriver);

NetflixPipeline.Login(webDriver);

NetflixPipeline.EnterInPerfil(webDriver);

NetflixPipeline.SearchMedia(webDriver);

var mediaSearched = NetflixPipeline.GetMediaDirectly(webDriver);
if (mediaSearched == null)
{
    Console.WriteLine("Nada encontrado!");
}
else
{
    // Console.WriteLine("_________________AQUI___________________");
    // Console.WriteLine(mediaSearched.Text);

    Console.WriteLine("Você deseja assitir " + mediaSearched.Text + "? (s/n):");
    string loadVideoSearched = Console.ReadLine()!.ToLower();

    if (loadVideoSearched == "s")
        mediaSearched.Click();
    else
        NetflixPipeline.GetSearchedMedias(webDriver);
}

NetflixPipeline.GetSearchedMedias(webDriver);
#endregion
*/


#region Generic_Methods_Version

IWebDriver _webDriver = new ChromeDriver();

string menuSearch;
string openedWebsiteUrl = null!;
do
{
    Console.WriteLine("___________MENU___________");
    Console.WriteLine("site: " + openedWebsiteUrl);
    Console.WriteLine("[0] Sair");
    Console.WriteLine("[1] Entrar no site");
    Console.WriteLine("[2] Clicar em botão");
    Console.WriteLine("[3] Inserir valor em input do form");
    Console.WriteLine("[4] Preencher Input");
    Console.WriteLine("[5] Descer tela");
    Console.WriteLine("[6] Subir tela");
    Console.WriteLine("_________________________");
    menuSearch = Console.ReadLine()!;

    switch (menuSearch)
    {
        case "1":
            Console.Clear();
            Console.Write("Insira o nome do site: ");
            string siteName = Console.ReadLine()!;
            openedWebsiteUrl = GenericWebMethods.OpenWebsite(_webDriver, siteName);
            break;
        case "2":
            Console.Clear();
            Console.Write("Insira o contéudo do botão: ");
            string btnContent = Console.ReadLine()!;
            GenericWebMethods.ClickButton(_webDriver, btnContent);
            break;
        case "3":
            Console.Clear();
            GenericWebMethods.InsertInputValueInForm(_webDriver);
            break;
        case "4":
            Console.Clear();
            GenericWebMethods.InsertInputValue(_webDriver);
            break;
        case "5":
            Console.Clear();
            GenericWebMethods.ScrollWindow(_webDriver, "-");
            break;
        case "6":
            Console.Clear();
            GenericWebMethods.ScrollWindow(_webDriver, "+");
            break;
        case "0":
            GenericWebMethods.QuitSession(_webDriver);
            break;
        default:
            break;
    }
} while (menuSearch != "0");

#endregion
