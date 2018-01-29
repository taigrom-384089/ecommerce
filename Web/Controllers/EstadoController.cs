using Dominio.Entidade;
using Dominio.Persistencia.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers
{
    public class EstadoController : ApiController
    {
        [HttpGet]
        [ActionName("Estados")]
        public IList<Estado> Todos()
        {
            return Repositorio.Estados.BuscarTodos().ToList();
        }
    }
}
