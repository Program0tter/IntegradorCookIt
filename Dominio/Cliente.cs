using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Cliente : Usuario
    {
        List<IngredienteConCantidad> _MisIngredientes { set; get; }
        List<RecetaConFecha> _HistorialRecetas { set; get; }
        List<RecetaConFecha> _RecetasFavoritas { set; get; }

        //Constructor para traer de BD
        public Cliente(int Id, string Email, string Foto, string NombreUsuario, string Nombre, string Apellido,
            List<IngredienteConCantidad> MisIng, List<RecetaConFecha> HistRec, List<RecetaConFecha> RecFav)
        : base(Id, Email, Foto, NombreUsuario, Nombre, Apellido)
        {
            _MisIngredientes = MisIng;
            _HistorialRecetas = HistRec;
            _HistorialRecetas = RecFav;
        }


        //Creacion de nuevo Cliente
        public Cliente(string Email, string Pass, string Foto, string NombreUsuario, string Nombre, string Apellido)
        : base(Email, Pass, Foto, NombreUsuario, Nombre, Apellido)
        {
            _MisIngredientes = new List<IngredienteConCantidad>();
            _HistorialRecetas = new List<RecetaConFecha>();
            _HistorialRecetas = new List<RecetaConFecha>();
        }

        public override string QueSoy() {
            return "Cliente";
        }

    }
}
