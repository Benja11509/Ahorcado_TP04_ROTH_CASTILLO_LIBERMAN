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
        partida Ahorcado = new partida();
        Ahorcado.crearPartida();

        HttpContext.Session.SetString("partida", Objeto.ObjectToString(Ahorcado));

        return View("Index");
    }

    public IActionResult Juego()
    {
        partida a = Objeto.StringToObject<partida>(HttpContext.Session.GetString("partida"));

        ViewBag.Palabra = a.Palabra;
        ViewBag.LetrasUsadas = a.LetrasUsadas;
        ViewBag.LetrasAdivinadas = a.LetrasAdivinadas;
        ViewBag.Intentos = a.Intentos;

        return View("Juego");
    }

    [HttpPost]
    public IActionResult AdivinarLetra(char letraTirada)
    {
        partida a = Objeto.StringToObject<partida>(HttpContext.Session.GetString("partida"));

        a.IngresarLetra(letraTirada);

        HttpContext.Session.SetString("partida", Objeto.ObjectToString(a));

        ViewBag.Intentos = a.Intentos;
        ViewBag.Palabra = a.Palabra;
        ViewBag.LetrasUsadas = a.LetrasUsadas;
        ViewBag.LetrasAdivinadas = a.LetrasAdivinadas;

        if (!a.LetrasAdivinadas.Contains('_'))
        {
            ViewBag.Ganaste = true;
            ViewBag.Palabra = a.Palabra;

            return View("Final");
        }

        return View("Juego");
    }
    public IActionResult AdivinarPalabra(string palabraTirada)
    {
        partida a = Objeto.StringToObject<partida>(HttpContext.Session.GetString("partida"));

        if (palabraTirada == null)
        {

            return View("Juego");
        }
        ViewBag.Ganaste = a.IngresarPalabra(palabraTirada);
        ViewBag.Palabra = a.Palabra;

        return View("Final");
    }

}
