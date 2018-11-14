using System;
using System.Collections.Generic;
using System.Text;

namespace InterfazUsuario.Modelo
{
    public class Filtro
    {
        string _Nombre { set; get; }

        public Filtro(string Nombre)
        {
            _Nombre = Nombre;
        }

    }
}
