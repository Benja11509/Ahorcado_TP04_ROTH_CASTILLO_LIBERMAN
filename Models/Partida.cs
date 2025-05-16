using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TP04.Models
{
    public static class partida
    {

        public static string Palabra { get; private set; }
        public static List<char> LetrasUsadas { get; private set; }
        public static char[] LetrasAdivinadas;
        public static string[] opciones = new string[] { "Agujero", "Platano", "Auto", "Dibujo", "Escuela", "Fiesta", "Galleta", "Héroico", "Juguete" };



        public static void crearPartida()
        {
            Random r = new Random();
            Palabra = opciones[r.Next(1, 10)];

            LetrasUsadas = new List<char>();

            char[] LetrasAdivinadas = new char[Palabra.Length];

            for (int i = 0; i == Palabra.Length; i++)
            {

                LetrasAdivinadas[i] = '_';
            }

        }
        public static char[] IngresarLetra(char letra)
        {
            letra = char.ToUpper(letra);

            if (LetrasUsadas.Contains(letra))
            {
                return LetrasAdivinadas;

            }
            else
            {
                LetrasUsadas.Add(letra);

                if (!Palabra.Contains(letra))
                {
                    LetrasUsadas.Add(letra);
                }
                else
                {
                    LetrasUsadas.Add(letra);
                    LetrasAdivinadas[Palabra.IndexOf(letra)] = letra;

                    //FRAN DSPS ARREGLÁ QUE ESTO SÓLO VA A FUNCIONAR PARA UNA LETRA :V XD XDDDDDDD//
                }

                return LetrasAdivinadas;
            }

        }
        public static bool IngresarPalabra(string p)
        {

            if (p == Palabra)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}