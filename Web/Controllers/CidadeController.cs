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
    public class CidadeController : ApiController
    {
        [HttpGet]
        [ActionName("Cidades")]
        public IList<Cidade> Todas()
        {
            return Repositorio.Cidades.BuscarTodos().ToList();
        }

        [HttpGet]
        [ActionName("Cidades")]
        public IList<Cidade> BuscarPorEstado(Int32 idEstado)
        {
            return Repositorio.Cidades
                .BuscarTodos()
                .Where(c => c.Estado.Id == idEstado)
                .ToList();
        }
    }
}
