using System;
using Dominio;

namespace ConsolaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente usr = new Cliente();
            try
            {
                usr = (Cliente)usr.Login("1", "3747");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
