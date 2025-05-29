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
        ViewBag.Intentos = partida.Intentos;

        return View("Juego");
    }

    [HttpPost]
    public IActionResult AdivinarLetra(char letraTirada)
    {
        partida.IngresarLetra(letraTirada);
        ViewBag.Intentos = partida.Intentos;
        ViewBag.Palabra = partida.Palabra;
        ViewBag.LetrasUsadas = partida.LetrasUsadas;
        ViewBag.LetrasAdivinadas = partida.LetrasAdivinadas;

        if (!partida.LetrasAdivinadas.Contains('_'))
        {
            ViewBag.Ganaste = true;
            ViewBag.Palabra = partida.Palabra;

            return View("Final");
        }

        return View("Juego");
    }
    public IActionResult AdivinarPalabra(string palabraTirada)
    {
        if (palabraTirada == null)
        {

            return View("Juego");
        }
        ViewBag.Ganaste = partida.IngresarPalabra(palabraTirada);
        ViewBag.Palabra = partida.Palabra;

        return View("Final");
    }
    partida party = new partida(email, password);
    HttpContext.Session.SetString("user", Objeto.ObjectToString(usu));

    ViewBag.User = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("user"));
    if(ViewBag.User is null)
    List<Usuario> users = new List<Usuario>();
    HttpContext.Session.SetString("users", Objetos.ListToString(users));
    ViewBag.Users Objetos.StringToList<Usuario>(HttpContext.Session.GetString("users"));
    if(ViewBag.Users is null)

}
