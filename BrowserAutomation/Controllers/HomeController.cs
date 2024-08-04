using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BrowserAutomation.Models;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace BrowserAutomation.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public JsonResult OpenWebsiteRequest(string websiteName)
    {
        // Gets the existent WebDriver instance
        var _webDriver = WebDriverManager.Instance;
        bool wasWebsiteOpenedSuccessfuly = GenericWebMethods.OpenWebsite(_webDriver, websiteName);

        if (wasWebsiteOpenedSuccessfuly)
            return Json($"Site {websiteName} aberto! ");
        else
            return Json($"Não foi possível acessar o site solicitado, verifique o nome inserido: {websiteName}");
    }

    [HttpPost]
    public JsonResult PressButton(string buttonText)
    {
        var _webDriver = WebDriverManager.Instance;
        int wasBtnClickedSuccessfuly = GenericWebMethods.ClickButton(_webDriver, buttonText);

        // Status ação
        if (wasBtnClickedSuccessfuly == 1)
            return Json("Botão normal clicado!");
        else if (wasBtnClickedSuccessfuly == 2)
            return Json("Botão span clicado!");
        else
            return Json("Houve algum erro!");
    }


    [HttpPost]
    public JsonResult InsertInputValue(string searchingInput, string newInputValueInserted)
    {
        var _webDriver = WebDriverManager.Instance;
        bool wasInputInsertedSuccessfuly = GenericWebMethods.InsertInputValue(_webDriver, searchingInput, newInputValueInserted);

        if (wasInputInsertedSuccessfuly)
            return Json($"Texto inserido com sucesso!: {newInputValueInserted}");
        else
            return Json($"Não foi possível inserir o valor no input desejado! Verifique a identificação do input passado!");
    }





    [HttpPost]
    public void QuitSession()
    {
        // Gets the existent WebDriver instance
        var _webDriver = WebDriverManager.Instance;
        _webDriver.Close();
        // Environment.Exit(0);
    }

    [HttpGet]
    public JsonResult GetDados()
    {
        string text = "Banana fofona é boa";
        return Json(text);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }
}
