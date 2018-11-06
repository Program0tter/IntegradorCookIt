using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Usuario
    {
        int _Id;
        String _Nombre;
        String _Email;
        String _Pass;
        String _Foto;

        

        List<RecetaConFecha> historialRecetas;
        List<RecetaConFecha> recetasFavoritas;
    }
}
