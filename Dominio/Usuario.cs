using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Usuario
    {
        int _Id;
        string _Email;
        string _Pass;
        string _Foto;
        string _NombreUsuario;
        string _Nombre;
        string _Apellido;

        public Usuario(int Id, string Email, string Pass, string Foto, string NombreUsuario, string Nombre, string Apellido) {
            _Id = Id;
            _Email = Email;
            _Pass = Pass;
            _Foto = Foto;
            _NombreUsuario = NombreUsuario;
            _Nombre = Nombre;
            _Apellido = Apellido;
        }



        public abstract string QueSoy();

    }
}
