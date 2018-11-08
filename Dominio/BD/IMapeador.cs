using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Dominio.BD
{
    public interface IMapeador
    {
        bool Insertar();

        bool Actualizar();

        void Borrar();

        string Select();

        void GenerarObjetoPrincipal(SqlDataReader dr);

        void GenerarObjetoSubordinado(SqlDataReader dr);
    }
}