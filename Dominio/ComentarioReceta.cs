using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class ComentarioReceta
    {
        int _Id { get; set; }
        Cliente _Usuario { get; set; }
        string _Comentario { get; set; }
        DateTime _Fecha { get; set; }
        int _Puntaje { get; set; }

        public ComentarioReceta(int Id, Cliente Usuario, string Comentario, DateTime Fecha, int Puntaje)
        {
            _Id = Id;
            _Usuario = Usuario;
            _Comentario = Comentario;
            _Fecha = Fecha;
            _Puntaje = Puntaje;           

        }

        public ComentarioReceta(Cliente Usuario, string Comentario, DateTime Fecha, int Puntaje)
        {
            _Usuario = Usuario;
            _Comentario = Comentario;
            _Fecha = Fecha;
            _Puntaje = Puntaje;
        }
    }
}
