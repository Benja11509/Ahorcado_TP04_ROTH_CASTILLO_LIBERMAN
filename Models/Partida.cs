using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TP04.Models
{
    public static class Partida
    {

        public static string Palabra { get; private set; }
        public static List<char> LetrasUsadas { get; private set; }
        public static bool Vivo { get; private set; }

        public static string[] opciones = new string[] { "Agujero", "Platano", "Auto", "Dibujo", "Escuela", "Fiesta", "Galleta", "Héroico", "Juguete" };

        public static void crearPartida()
        {
            Random r = new Random();
            Palabra = opciones[r.Next(1, 10)];

            LetrasUsadas = new List<char>();

            Vivo = true;
        }
        public static bool IngresarLetra(char letra)
        {
            letra = char.ToUpper(letra);

            if (LetrasUsadas.Contains(letra) || !Vivo)
            {
                return false;

            }
            else
            {
                LetrasUsadas.Add(letra);




                if (!Palabra.Contains(letra))
                {
                    if (LetrasUsadas.Count(l => !Palabra.Contains(l)) >= 6) // Puedes cambiar 6 por el máximo de errores
                        Vivo = false;
                }
                else if (Palabra.All(c => LetrasUsadas.Contains(c)))
                {
                    Gano = true;
                    Vivo = false;
                }

                return true;
            }

        }




    }}