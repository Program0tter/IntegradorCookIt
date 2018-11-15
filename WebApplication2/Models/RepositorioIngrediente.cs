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
            _Ingredientes = ManejadorIngredientes.GetIngredientes();
        }

        public IEnumerable<Ingrediente> GetAll()
        {
            return _Ingredientes;
        }

        public Ingrediente Find(int id)
        {
            return ManejadorIngredientes.FindIngrediente(id);
        }

        internal void Insert(Ingrediente ing)
        {
            ManejadorIngredientes.InsertarIng(ing);
        }
    }
}