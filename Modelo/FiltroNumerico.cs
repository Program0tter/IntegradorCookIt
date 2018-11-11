using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class FiltroNumerico : Filtro
    {
        public int _Valor { set; get; }
        public string _Simbolo { set; get; }
        public FiltroNumerico(string Nombre, int Valor, string Simbolo) : base(Nombre)
        {
            _Valor = Valor;
            _Simbolo = Simbolo;
        }

        public override string ToString()
        {
            //momentoDia = 
            return base.ToString() + " " + _Simbolo + " " + _Valor;            
        }

    }
}
