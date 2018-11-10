using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Dominio.BD;

namespace Dominio
{
    public class PasoReceta : IMapeador
    {
        public int _Id { set; get; }
        public int _IdReceta { set; get; }
        public string _Texto { set; get; }
        public int _TiempoReloj { set; get; }
        public string _UrlVideo { set; get; }
        //FALTA ESTO
        public Image imagen;

        public bool Insertar()
        {
            throw new NotImplementedException();
        }

        public bool Actualizar()
        {
            throw new NotImplementedException();
        }

        public bool Borrar()
        {
            throw new NotImplementedException();
        }
    }
}
