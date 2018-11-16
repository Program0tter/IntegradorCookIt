using System;
using WebApplication2;
using Modelo;

namespace ConsolaTest
{
    class Program
    {
        static void Main(string[] args)
        {
/*
            Ingrediente ing = new Ingrediente("Pepegrillo5", 100, 1, 10, 10, 10, false, false, false, false, 1, 1);
            ing.Insertar();
            */
            Cliente usr = new Cliente();
            try
            {                
                usr.Login("daniel.r.23@gmail.com", "Piripitiflautico2018");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
