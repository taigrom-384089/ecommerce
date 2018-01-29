using Dominio.InjecaoDependencia.Entidade;
using Dominio.Integracao.Interfaces;
using Dominio.Persistencia.Interfaces;
using Infra.NHibernate;
using Infra.Persistencia.Persistencia;
using Infra.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;

namespace Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private void ConfigurarIoC()
        {
            ResolvedorDependencia.Configurar(
                (container) =>
                {
                    container.RegisterType(typeof(IServicoLog), typeof(ServicoLog));
                    container.RegisterType<IRepositorioTelefone, RepositorioTelefone>();
                    container.RegisterType<IRepositorioCliente, RepositorioCliente>();
                    container.RegisterType<IRepositorioBairro, RepositorioBairro>();
                    container.RegisterType<IRepositorioCidade, RepositorioCidade>();
                    container.RegisterType<IRepositorioEstado, RepositorioEstado>();
                    container.RegisterType<IRepositorioCep, RepositorioCep>();
                    container.RegisterType<ISessionManager, SessionManager>();
                    container.RegisterType<ITransacao, Transacao>();
                });
        }


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigurarIoC();

            SessionProvider.Start();
        }
    }
}
