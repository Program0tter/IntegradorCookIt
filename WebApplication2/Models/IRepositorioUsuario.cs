using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public interface IRepositorioUsuario
    {
        Usuario find(int id);
        void InsertCliente(Cliente cli);
        void UpdateCliente(Cliente cli);

    }
}
