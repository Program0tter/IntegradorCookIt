using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Usuario
    {
        int _Id;
        string _Nombre;
        string _Email;
        string _Pass;
        string _Foto;

        List<RecetaConFecha> historialRecetas;
        List<RecetaConFecha> recetasFavoritas;
    }
}
