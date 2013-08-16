using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using CRM.Api;
using Infrastructure;
using Repository;
using Service;
using WebMatrix.WebData;

namespace CRM.App_Start
{

    public static class Bootstrapper
    {
        public static void Start()
        {
            InitializeDatabase();
            SetAutofacContainer();
        }
        private static void InitializeDatabase()
        {

            Database.SetInitializer<CRMContext>(new CRMContextInitializer());
            var context = new CRMContext();
            context.Database.Initialize(true);
        }

        private static void SetAutofacContainer()
        {
            //Create Autofac builder
            var builder = new ContainerBuilder();
            //Now register all depedencies to your custom IoC container

            builder.RegisterType<DatabaseFactory<CRMContext>>()
                   .As<IDatabaseFactory<CRMContext>>()
                   .InstancePerHttpRequest();


            builder.RegisterType<UnitOfWork<CRMContext>>().As<IUnitOfWork<CRMContext>>().WithParameter("databaseFactor", new DatabaseFactory<CRMContext>()).InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(typeof(AccountRepository).Assembly)
          .Where(t => t.Name.EndsWith("Repository"))
          .AsImplementedInterfaces().InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(typeof(AccountService).Assembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces().InstancePerHttpRequest();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // Register the Web API controllers.
            builder.RegisterApiControllers(typeof(ManageAccountController).Assembly);

            var containerBuilder = builder.Build();

            //MVC resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(containerBuilder));


            // Create the depenedency resolver for Web Api
            var resolverWebApi = new AutofacWebApiDependencyResolver(containerBuilder);

            // Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = resolverWebApi;



          


        }
    }
}

