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
        public static string[] opciones = new string[] { "LUNA", "NIEVE", "PERROS", "GALLETA", "MONTAJE", "ESCRITOR", "FOTOGRAMA" };
        public static int Intentos { get; private set; }

        public static void crearPartida()
        {
            if (Palabra == null)
            {
                Random r = new Random();
                Palabra = opciones[r.Next(1, opciones.Length)];
            }

            LetrasUsadas = new List<char>();

            if (LetrasAdivinadas == null)
            {
                LetrasAdivinadas = new char[Palabra.Length];

                for (int i = 0; i < Palabra.Length; i++)
                {
                    LetrasAdivinadas[i] = '_';
                }
            }

            Intentos  = 0;

        }
        public static char[] IngresarLetra(char letra)
        {
            letra = char.ToUpper(letra);

            if(letra >= 65 && letra <= 90){

            

            if (LetrasUsadas.Contains(letra))
            {
                return LetrasAdivinadas;
            }

            LetrasUsadas.Add(letra);

            if (Palabra.Contains(letra))
            {
                for (int i = 0; i < Palabra.Length; i++)
                {
                    if (Palabra[i] == letra)
                    {
                        LetrasAdivinadas[i] = letra;
                    }
                }
            }}

            string LA = new string(LetrasAdivinadas);
            
            if(Palabra == LA){
                
                IngresarPalabra(LA);
            }

            return LetrasAdivinadas;
        }
        public static bool IngresarPalabra(string palabra)
        {

            if (palabra.ToUpper() == Palabra)
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