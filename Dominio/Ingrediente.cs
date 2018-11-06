using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Ingrediente
    {
        public enum Tipo { Frutas = 1, Verduras = 2, Lacteos = 3, Carnes = 4,
            PescadosMariscos = 5, Legumbres = 6, FrutosSecosSemillas = 7,
            Cereales = 8, SalsasAderezos = 9, AceitesGrasas = 10, ParaHornear = 11,
            EspeciasHierbas = 12 }
        public enum Estacion { Verano = 1, Otono = 2, Invierno = 3, Primavera = 4, Varios = 5}

        //1 = mg, 2 = ml
        public enum TipoMedida { Mg = 1, Ml = 2 }



        public Estacion _Estacion { set; get; }
        public Tipo _Tipo { set; get; }

        public Ingrediente(int idTipo, int idEstacion) {
            _Estacion = (Estacion) idEstacion;
            _Tipo = (Tipo) idTipo;
        }
    }
}
