using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class RepositorioIngrediente
    {
        private List<Ingrediente> _Ingredientes;

        public RepositorioIngrediente()
        {
            InicializarDatos();
        }

        private void InicializarDatos()
        {
            _Ingredientes = DalHelper.GetIngredientes();
        }

        public IEnumerable<Ingrediente> GetAll()
        {
            return _Ingredientes;
        }

        public Ingrediente Find(int id)
        {
            return DalHelper.FindIngrediente(id);
        }

        internal void Insert(Ingrediente ing)
        {
            DalHelper.InsertarIng(ing);
        }
    }
}