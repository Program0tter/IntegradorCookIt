using System;
using Dominio;

namespace ConsolaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Ingrediente ing = new Ingrediente(1, 3);
            Console.WriteLine("Info ingrediente: " + ing._Estacion + " - " + ing._Tipo);
            Console.ReadKey();
        }
    }
}
