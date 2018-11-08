using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Administrador : Usuario
    {
        public Administrador(int Id, string Email, string Foto, string NombreUsuario, string Nombre, string Apellido) : 
            base(Id, Email, Foto, NombreUsuario, Nombre, Apellido)
        {
        }

        public Administrador(string Email, string Pass, string Foto, string NombreUsuario, string Nombre, string Apellido) : 
            base(Email, Pass, Foto, NombreUsuario, Nombre, Apellido)
        {
        }

        public override string QueSoy()
        {
            return "Administrador";
        }
    }
}
