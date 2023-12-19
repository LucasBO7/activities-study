using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Compras.Models;
using Compras.Infra;
using Compras.Models.Formularies;

namespace Compras.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    Context context = new Context();

    public IActionResult GetAlternative()
    {
        string alternativeElement = @"<select name='' id=''>
            <option value='banana'>Banana</option>
            <option value='apple'>Maçã</option>
            <option value='tomatoe'>Tomate</option>
        </select>";

        ViewBag.Content = alternativeElement;
        ViewBag.AlternativeBtnClicked = true;

        return RedirectToAction("Index", "Home", alternativeElement);
    }

    public IActionResult Index()
    {
        // Modo 1
        var clientes = context.Clientes.ToList();
        var compras = context.Compras.ToList();

        Cliente cliente = clientes.First(cl => cl.Id == 2);
        cliente.Compras = compras.FindAll(c => c.ClienteId == cliente.Id);

        ViewBag.Cliente = cliente;

        // Modo 2
        // context.Clientes.ToList();



        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
