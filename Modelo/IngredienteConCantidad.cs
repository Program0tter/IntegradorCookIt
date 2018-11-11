using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public abstract class IngredienteConCantidad
    {

        public Ingrediente _Ingrediente { get; set; }
        public int _Cantidad { get; set; }

        public IngredienteConCantidad(Ingrediente Ing, int Cantidad){
            _Ingrediente = Ing;
            _Cantidad = Cantidad;
        }
    }
}
