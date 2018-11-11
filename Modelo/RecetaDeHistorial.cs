using Persistencia;
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class RecetaDeHistorial : RecetaConFecha, IMapeador
    {
        public RecetaDeHistorial(Receta Receta, DateTime Fecha) : base(Receta, Fecha)
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

        internal static List<RecetaDeHistorial> TraerConIdUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}