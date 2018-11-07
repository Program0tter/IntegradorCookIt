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

        public Cliente(int Id, string Email, string Pass, string Foto, string NombreUsuario, string Nombre, string Apellido)
        :base(Id, Email, Pass, Foto, NombreUsuario, Nombre, Apellido)
        {
        
        }

        override
        public string QueSoy() {
            return "Cliente";
        }
    }
}
