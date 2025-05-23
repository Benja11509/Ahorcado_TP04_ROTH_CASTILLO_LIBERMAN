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

    public IActionResult Juego()
    {
        ViewBag.Palabra = partida.Palabra;
        ViewBag.LetrasUsadas = partida.LetrasUsadas;
        ViewBag.LetrasAdivinadas = partida.LetrasAdivinadas;

        return View("Juego");
    }

    [HttpPost]
    public IActionResult AdivinarLetra(char letraTirada)
    {
        partida.IngresarLetra(letraTirada);
        ViewBag.Intentos += 1;
        ViewBag.Palabra = partida.Palabra;
        ViewBag.LetrasUsadas = partida.LetrasUsadas;
        ViewBag.LetrasAdivinadas = partida.LetrasAdivinadas;

        return View("Juego");
    }
    public IActionResult AdivinarPalabra(string palabraTirada)
    {

        ViewBag.Ganaste = partida.IngresarPalabra(palabraTirada);
        ViewBag.Palabra = partida.Palabra;
        ViewBag.DuraciónPalabra = (partida.Palabra).Length;

        return View("Final");
    }

}
