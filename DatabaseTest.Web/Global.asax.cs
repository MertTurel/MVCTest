using Autofac;
using Autofac.Integration.Mvc;
using DatabaseTest.Web.Models.Data;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using DatabaseTest.Web.Models.Mapping;

namespace DatabaseTest.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<TestDbContext>().As<DbContext>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<MapperProfile>());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
