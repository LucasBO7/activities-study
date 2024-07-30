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
    public void OpenWebsiteRequest(string websiteName)
    {
        // Gets the existent WebDriver instance
        var _webDriver = WebDriverManager.Instance;
        GenericWebMethods.OpenWebsite(_webDriver, websiteName);
    }

    [HttpPost]
    public void PressButton(string buttonText){
        var _webDriver = WebDriverManager.Instance;
        GenericWebMethods.ClickButton(_webDriver, buttonText);
    }



    public void InsertInputValue(string searchingInput, string newInputValue){
        
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
