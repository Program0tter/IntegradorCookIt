using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Persistencia
{
    public interface IMapeador
    {
        bool Insertar();

        bool Actualizar();

        bool Borrar();
    }
}