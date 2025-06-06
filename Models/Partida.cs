using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TP04.Models
{
    public class partida
    {
        [JsonProperty]
        public string Palabra { get; private set; }
        [JsonProperty]
        public List<char> LetrasUsadas { get; private set; }
        [JsonProperty]
        public char[] LetrasAdivinadas { get; private set; }
        [JsonProperty]
        public string[] opciones = new string[] { "LUNA", "NIEVE", "PERROS", "GALLETA", "MONTAJE", "ESCRITOR", "FOTOGRAMA" };
        [JsonProperty]
        public int Intentos { get; private set; }
        [JsonProperty]
        public bool pCompleta { get; private set; }

        public void crearPartida()
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

            pCompleta = false;

            Intentos = 0;

        }
        public char[] IngresarLetra(char letra)
        {
            letra = char.ToUpper(letra);

            if (letra >= 65 && letra <= 90)
            {

                if (LetrasUsadas.Contains(letra))
                {
                    return LetrasAdivinadas;
                }

                Intentos++;

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
                }
            }


            return LetrasAdivinadas;
        }
        public bool IngresarPalabra(string palabra)
        {

            if (palabra.ToUpper() == Palabra)
            {
                pCompleta = true;
            }
            else
            {
                pCompleta = false;
            }

            return pCompleta;

        }
    }
}