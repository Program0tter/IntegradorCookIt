using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dominio.BD
{
    public class MapeadorIngrediente : IMapeador
    {

        Ingrediente _Ing { set; get; }

        public MapeadorIngrediente(Ingrediente ing)
        {
            _Ing = ing;
        }

        public void Insertar()
        {

        }

        public void Actualizar()
        {
            throw new NotImplementedException();
        }

        public void Borrar()
        {
            throw new NotImplementedException();
        }

        public string Select()
        {
            throw new NotImplementedException();
        }

        public void GenerarObjetoPrincipal(SqlDataReader dr)
        {
            throw new NotImplementedException();
        }

        public void GenerarObjetoSubordinado(SqlDataReader dr)
        {
            throw new NotImplementedException();
        }

    }
}
