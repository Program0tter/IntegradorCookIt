using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly RepositorioUsuario ru;
        
        public UsuarioController()
        {
            ru = new RepositorioUsuario();
        }

        [HttpGet]
        public Cliente LoginCliente(string email, string pass)
        {
            var cli = ru.LoginCliente(email, pass);
            return cli;
        }

        [HttpPost]
        public void Post([FromBody] Cliente cli)
        {
            ru.InsertCliente(cli);
        }

        [HttpPut]
        public void Put(int id, [FromBody] Cliente cli)
        {
            cli._Id = id;
            ru.UpdateCliente(cli);
        }

    }
}
