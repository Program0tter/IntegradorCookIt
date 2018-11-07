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
        string _SobreNombre;
        string _Nombre;
        string _Apellido;

        public abstract string QueSoy();

    }
}
