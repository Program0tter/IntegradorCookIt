using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly RepositorioCliente _RepoCli;

        public ClientesController()
        {
            _RepoCli = new RepositorioCliente();
        }

        [HttpGet]
        public Cliente GetCliente(string correo, string pass)
        {
            var cli = _RepoCli.Login(correo, pass);
            return cli;
        }

        public IEnumerable<Cliente> GetAll()
        {
            var cli = _RepoCli.GetAll();
            return cli;
        }

        [HttpPost]
        public void PostCliente([FromBody]Cliente cli)
        {
            _RepoCli.Registrar(cli);
        }

        [HttpPut]
        public void PutClientePerfil(Cliente cli)
        {
            _RepoCli.ActualizarPerfil(cli);
        }
    }
}
