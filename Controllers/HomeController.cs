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
        partida.crearPartida();

        return View("Index");
    }
    [HttpPost]
    public IActionResult AdivinarLetra(List<char> letrasUsadas, char[] letrasAdivinadas, char letraTirada)
    {
        partida.crearPartida();
        partida.IngresarLetra(letraTirada);
        ViewBag.Palabra = partida.Palabra;
        ViewBag.LetrasUsadas = partida.LetrasUsadas;        
        ViewBag.LetrasAdivinadas = partida.LetrasAdivinadas;

        return View("Juego");
    }
    public IActionResult AdivinarPalabra(List<char> letrasUsadas, char[] letrasAdivinadas, string palabraTirada)
    {
        partida.crearPartida();
        partida.IngresarPalabra(palabraTirada);
        ViewBag.DuraciónPalabra = (partida.Palabra).Length;

        return View("Juego");
    }

}
