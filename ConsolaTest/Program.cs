using System;
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
                //Cliente cli = new Cliente();
                //cli._Email = "daniel.r.23@gmail.com";
                //cli._Pass = "Piripitiflautico2018";
                //cli._NombreUsuario = cli._Email;                
                //cli.Insertar();
         
                usr = (Cliente)usr.Login("daniel.r.23@gmail.com", "Piripitiflautico2018");
                usr._Nombre = "Daniel Leandro";
                usr._Apellido = "Ramos Viñas";
                usr._NombreUsuario = "daniel.r.23";
                usr._Foto = null;
                usr.ActualizarPerfil();


                //usr = (Cliente)usr.Login("1", "3747");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
