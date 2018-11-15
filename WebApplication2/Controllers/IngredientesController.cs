using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class IngredientesController : ApiController
    {
        private readonly RepositorioIngrediente _RepoIng;

        public IngredientesController()
        {
            _RepoIng = new RepositorioIngrediente();
        }

        [HttpGet]
        public IEnumerable<Ingrediente> List()
        {
            return _RepoIng.GetAll();
        }

        public Ingrediente GetIngrediente(int id)
        {
            var Ingrediente = _RepoIng.Find(id);
            return Ingrediente;
        }

        [HttpPost]
        public void PostIng([FromBody]Ingrediente ing)
        {
            _RepoIng.Insert(ing);
        }


    }
}
