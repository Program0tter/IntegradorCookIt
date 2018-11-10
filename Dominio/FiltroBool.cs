using Dominio.BD;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class FiltroBool : Filtro
    {
        bool _Boolean { set; get; }
        public FiltroBool(string Nombre, bool Boolean) : base(Nombre)
        {
            _Boolean = Boolean;
        }

        public override string ToString()
        {
            int valor = (_Boolean) ? 1 : 0;
            return base.ToString() + " = " + valor;
        }

        public bool Insertar()
        {
            throw new NotImplementedException();
        }

        public bool Actualizar()
        {
            throw new NotImplementedException();
        }

        public bool Borrar()
        {
            throw new NotImplementedException();
        }
    }
}
