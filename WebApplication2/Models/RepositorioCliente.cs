using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class RepositorioCliente
    {


        public RepositorioCliente()
        {

        }

        public Cliente Login(string correo, string pass)
        {
            return ManejadorClientes.Login(correo, pass);
        }

        public bool Registrar(Cliente cli)
        {
            return ManejadorClientes.Registrar(cli);
        }
        
        public bool ActualizarPerfil(Cliente cli)
        {
            return ManejadorClientes.ActualizarPerfil(cli);
        }

    }
}