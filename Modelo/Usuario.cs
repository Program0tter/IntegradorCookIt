using Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Text;

namespace Modelo
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

        public enum TipoUsuario { Administrador = 1 , Cliente = 2 };

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


        public abstract TipoUsuario QueSoy();

        public abstract object Login(string correo, string pass);

        public abstract bool Insertar();

        public abstract bool ActualizarPerfil();




    }
}
