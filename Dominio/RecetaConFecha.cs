using Dominio.BD;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class RecetaConFecha
    {

        public Receta _Receta { set; get; }
        public DateTime _Fecha { set; get; }

        public RecetaConFecha(Receta Receta, DateTime Fecha)
        {
            _Receta = Receta;
            _Fecha = Fecha;
        }

    }
}
