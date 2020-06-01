using Autofac;
using Autofac.Integration.Mvc;
using FootballLeague.DAL;
using FootballLeague.DAL.Interfaces;
using FootballLeague.DAL.Repositories;
using FootballLeague.Domain.Entities;
using FootballLeague.Service.Interfaces;
using FootballLeague.Service.Services;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FootballLeague.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<TeamRepository>().As<ITeamRepository>().InstancePerRequest();
            builder.RegisterType<MatchRepository>().As<IMatchRepository>().InstancePerRequest();
            builder.RegisterType<GenericRepository<Team>>().As<IGenericRepository<Team>>().InstancePerRequest();
            builder.RegisterType<GenericRepository<Match>>().As<IGenericRepository<Match>>().InstancePerRequest();
            builder.RegisterType<TeamService>().As<ITeamService>().InstancePerRequest();
            builder.RegisterType<MatchService>().As<IMatchService>().InstancePerRequest();
            builder.RegisterType<ApplicationDbContext>().InstancePerRequest();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
