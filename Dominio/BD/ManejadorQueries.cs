using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.BD
{
    public class ManejadorQueries
    {
        public void Guardar(Mapeador m)
        {
            if (m)
            {
                insertar(m);
            }
            else
            {
                actualizar(m);
            }
        }
    }
}
