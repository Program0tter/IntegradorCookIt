using System;
using System.Collections.Generic;
using Dominio.BD;

namespace Dominio
{
    public class RecetaFavorita : RecetaConFecha, IMapeador
    {
        public RecetaFavorita(Receta Receta, DateTime Fecha) : base(Receta, Fecha)
        {
        }

        public bool Actualizar()
        {
            throw new NotImplementedException();
        }

        public bool Borrar()
        {
            throw new NotImplementedException();
        }

        public bool Insertar()
        {
            throw new NotImplementedException();
        }

        internal static List<RecetaFavorita> TraerConIdUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}