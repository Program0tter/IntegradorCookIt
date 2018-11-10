using Dominio.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;

namespace Dominio
{
    public abstract class Usuario
    {
        public int _Id { set; get; }
        public string _Email { set; get; }
        public string _Pass { set; get; }
        public byte[] _Foto { set; get; }
        public string _NombreUsuario { set; get; }
        public string _Nombre { set; get; }
        public string _Apellido { set; get; }

        public Usuario() { }

        public Usuario(int Id, string Email, byte[] Foto, string NombreUsuario, string Nombre, string Apellido) {
            _Id = Id;
            _Email = Email;
            _Foto = Foto;
            _NombreUsuario = NombreUsuario;
            _Nombre = Nombre;
            _Apellido = Apellido;
        }
        public Usuario(string Email, string Pass, byte[] Foto, string NombreUsuario, string Nombre, string Apellido)
        {
            _Email = Email;
            _Pass = Pass;
            _Foto = Foto;
            _NombreUsuario = NombreUsuario;
            _Nombre = Nombre;
            _Apellido = Apellido;
        }


        public abstract string QueSoy();

        public abstract object Login(string correo, string pass);

    }
}
