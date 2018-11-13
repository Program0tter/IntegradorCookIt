using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Sistema
    {
        private static Sistema _Instancia;
        private Sistema() { }
        public static Sistema Instancia
        {
            get
            {
                if(_Instancia == null)
                {
                    _Instancia = new Sistema();
                }
                return _Instancia;
            }
        }

        public Cliente LoginCliente(string nombre, string pass)
        {
            Cliente cli = new Cliente();
            return (Cliente) cli.Login(nombre, pass);
        }

        public Administrador LoginAdmin(string nombre, string pass)
        {
            Administrador adm = new Administrador();
            return (Administrador) adm.Login(nombre, pass);
        }
    }
}
