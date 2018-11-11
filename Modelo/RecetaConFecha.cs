using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
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
