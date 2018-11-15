using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication2.Models
{
    public class Ingrediente
    {
        public enum Tipo
        {
             Frutas = 1,  Verduras = 2,  Lacteos = 3,  Carnes = 4,
             PescadosMariscos = 5,  Legumbres = 6,  FrutosSecosSemillas = 7,
             Cereales = 8,  SalsasAderezos = 9,  AceitesGrasas = 10,  ParaHornear = 11,
             EspeciasHierbas = 12
        }

        [Serializable]
        public enum Estacion { Verano = 1,  Otono = 2,  Invierno = 3,  Primavera = 4,  Varios = 5 }

        public int _Id { set; get; }
        public string _Nombre { set; get; }
        public int _Costo { set; get; }
        public string _Medida { set; get; }
        public int _MedidaPromedio { set; get; }
        public int _MedidaPorGramo { set; get; }
        public int _CantCaloriasPorMedida { set; get; }
        public bool _AptoCeliacos { set; get; }
        public bool _AptoDiabeticos { set; get; }
        public bool _AptoVegetarianos { set; get; }
        public bool _AptoVeganos { set; get; }
        public int _Estacion { set; get; }
        public int _Tipo { set; get; }
    }
}