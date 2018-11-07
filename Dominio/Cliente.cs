using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Cliente : Usuario
    {
        List<IngredienteConCantidad> _MisIngredientes;
        List<RecetaConFecha> historialRecetas;
        List<RecetaConFecha> recetasFavoritas;

        override
        public string QueSoy() {
            return "Cliente";
        }
    }
}
