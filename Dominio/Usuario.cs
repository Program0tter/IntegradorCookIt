using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Usuario
    {
        public int _Id;
        public string _Email;
        public string _Pass;
        public string _Foto;
        public string _SobreNombre;
        public string _Nombre;
        public string _Apellido;

        List<IngredienteConCantidad> _MisIngredientes;
        List<RecetaConFecha> historialRecetas;
        List<RecetaConFecha> recetasFavoritas;
    }
}
