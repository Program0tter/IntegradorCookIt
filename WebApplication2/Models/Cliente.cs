using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Cliente
    {
        public int _Id { set; get; }
        public string _Email { set; get; }
        public string _Pass { set; get; }
        public byte[] _Foto { set; get; }
        public string _NombreUsuario { set; get; }
        public string _Nombre { set; get; }
        public string _Apellido { set; get; }
    }
}