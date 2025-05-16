using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04.Models;

namespace TP04.Controllers;

public class HomeController : Controller
{

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Partida.crearPartida();
        ViewBag.Palabra = Partida.Palabra;
        ViewBag.Intentos = Partida.Palabra();
        ViewBag.Vivo = 
        return View();
    }

    public IActionResult Partida()
    {
    


        return View();
    

        }
}
