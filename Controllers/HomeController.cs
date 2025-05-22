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

        return View();
    }
    public IActionResult Juego(List<char> LU, char[] LA)
    {
        
        

        partida.crearPartida(LU, LA);
        
        ViewBag.Palabra = partida.Palabra;
        ViewBag.LetrasUsadas = partida.LetrasUsadas;
        ViewBag.LetrasAdivinadas = partida.LetrasAdivinadas;
        ViewBag.DuraciónPalabra = (partida.Palabra).Length;
        return View();
    }

}
