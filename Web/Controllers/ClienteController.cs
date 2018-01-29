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
    public class ClienteController : ApiController
    {
        [HttpGet]
        [ActionName("buscarporcpf")]
        public dynamic BuscarPorCpf(string cpf)
        {
            return Repositorio.Clientes.BuscarPorCpf(cpf);
        }

        [HttpGet]
        [ActionName("buscarpornome")]
        public List<Cliente> BuscarPorNome(string nome)
        {
            return Repositorio.Clientes.BuscarPorNome(nome).ToList();
        }

        [HttpGet]
        [ActionName("buscarporemail")]
        public Cliente BuscarPorEmail(string email)
        {
            return Repositorio.Clientes.BuscarPorEmail(email);
        }

        [HttpPost]
        [ActionName("gravar")]
        public HttpResponseMessage Gravar(Cliente cliente)
        {
            try
            {
                cliente.Validar();

                using (var transacao = Repositorio.Transacao)
                {
                    if (cliente.Id > 0)
                    {
                        var clienteExistente = Repositorio.Clientes.BuscarPorCpf(cliente.Cpf);
                        
                        if (clienteExistente != null)
                            clienteExistente.Atualizar(cliente);
                        else return new HttpResponseMessage(HttpStatusCode.OK);
                    }
                    else
                        cliente.Inserir();

                    transacao.Commit();

                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(new { Mensagem = ex.Message }));
            }
        }
    }
}
