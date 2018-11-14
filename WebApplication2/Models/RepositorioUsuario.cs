using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        List<Cliente> _Clientes;

        public RepositorioUsuario()
        {
            InicializarDatos();
        }

        private void InicializarDatos()
        {

        }

        public Usuario find(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente LoginCliente(string nombre, string pass)
        {
            Cliente cli = new Cliente();
            return (Cliente) cli.Login(nombre, pass);
        }

        public void InsertCliente(Cliente cli)
        {
            cli.Insertar();
        }

        public void UpdateCliente(Cliente cli)
        {
            cli.ActualizarPerfil();
        }
    }
}