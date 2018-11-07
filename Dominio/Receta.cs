using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace Dominio
{
    public class Receta
    {
        enum MomentoDia { Desayuno = 1, Cena = 2, Merienda = 3, Almuerzo = 4, DesayunoMerienda = 5, AlmuerzoCena = 6,
        Variado = 7 }

        int _Id { get; set; }
        MomentoDia _MomentoDia { get; set; }
        Ingrediente.Estacion _Estacion { get; set; }
        int _Dificultad { get; set; }
        int _TiempoPreparacion { get; set; }
        string _PaisOrigen { get; set; }
        string _Foto { get; set; }
        Usuario _Creador { get; set; }
        int _CantPlatos { get; set; }
        float _Costo { get; set; }
        DateTime _FechaCreacion { get; set; }
        float _PuntajeTotal { get; set; }
        bool _AptoCeliacos { get; set; }
        bool _AptoDiabeticos { get; set; }
        bool _AptoVegetarianos { get; set; }
        bool _AptoVeganos { get; set; }
        bool _Habilitada { get; set; }

        public Receta(int Id, int MomentoDia,int Estacion, int Dificultad, int TiempoPreparacion, string PaisOrigen, string Foto, Usuario Creador, int CantPlatos, float Costo,
            DateTime FechaCreacion, float PuntajeTotal, bool AptoCeliacos, bool AptoDiabeticos, bool AptoVegetarianos, bool AptoVeganos, bool Habilitada)
        {
            _Id = Id;
            _MomentoDia = (MomentoDia)MomentoDia;
            _Estacion = (Ingrediente.Estacion)Estacion;
            _Dificultad = Dificultad;
            _TiempoPreparacion = TiempoPreparacion;
            _PaisOrigen = PaisOrigen;
            _Foto = Foto;
            _Creador = Creador;
            _CantPlatos = CantPlatos;
            _Costo = Costo;
            _FechaCreacion = FechaCreacion;
            _PuntajeTotal = PuntajeTotal;
            _AptoCeliacos = AptoCeliacos;
            _AptoDiabeticos = AptoDiabeticos;
            _AptoVegetarianos = AptoVegetarianos;
            _AptoVeganos = AptoVeganos;            
            _Habilitada = (Creador.QueSoy().Equals("Administrador")) ? true : false;

        }

        public Receta(int MomentoDia, int Estacion, int Dificultad, int TiempoPreparacion, string PaisOrigen, string Foto, Usuario Creador, int CantPlatos, float Costo,
    DateTime FechaCreacion, float PuntajeTotal, bool AptoCeliacos, bool AptoDiabeticos, bool AptoVegetarianos, bool AptoVeganos, bool Habilitada)
        {     
            _MomentoDia = (MomentoDia)MomentoDia;
            _Estacion = (Ingrediente.Estacion)Estacion;
            _Dificultad = Dificultad;
            _TiempoPreparacion = TiempoPreparacion;
            _PaisOrigen = PaisOrigen;
            _Foto = Foto;
            _Creador = Creador;
            _CantPlatos = CantPlatos;
            _Costo = Costo;
            _FechaCreacion = FechaCreacion;
            _PuntajeTotal = PuntajeTotal;
            _AptoCeliacos = AptoCeliacos;
            _AptoDiabeticos = AptoDiabeticos;
            _AptoVegetarianos = AptoVegetarianos;
            _AptoVeganos = AptoVeganos;
            _Habilitada = (Creador.QueSoy().Equals("Administrador")) ? true : false;

        }

    }


}
