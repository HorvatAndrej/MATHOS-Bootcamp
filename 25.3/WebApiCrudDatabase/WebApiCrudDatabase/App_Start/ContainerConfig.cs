using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Vehicle.Repository;
using Vehicle.Repository.Common;
using Vehicle.Service;
using Vehicle.Service.Common;

namespace WebApiCrudDatabase.App_Start
{
    public class ContainerConfig
    {
        
        public static void Main()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EngineService>().As<IEngineService>();
            builder.RegisterType<ManufacturerService>().As<IManufacturerService>();
            builder.RegisterType<EngineRepository>().As<IEngineRepository>();
            builder.RegisterType<ManufacturerRepository>().As<IManufacturerRepository>();

            

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container=builder.Build();
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);





        }

        
    }
}