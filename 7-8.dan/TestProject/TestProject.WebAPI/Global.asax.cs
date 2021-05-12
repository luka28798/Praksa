using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using Animal.Repository;

using Animal.Repository.Common;


using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Human.Model.Common;
using Human.Model;
using Human.Repository;
using Human.Repository.Common;
using Human.Service.Common;
using Human.Service;

using System.Reflection;
using Animal.Model;
using Animal.Model.Common;
using Animal.Service;
using Animal.Service.Common;
using TestProject.WebAPI.Controllers;
using AutoMapper;
using Automapper.Model;

namespace TestProject.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<Animals>().As<IAnimalModel>();
            builder.RegisterType<AnimalRepository>().As<IAnimalRepository>();
            builder.RegisterType<AnimalService>().As<IAnimalService>();
            builder.RegisterType<People>().As<IHumanModel>();
            builder.RegisterType<HumanRepository>().As<IHumanRepository>();
            builder.RegisterType<HumanService>().As<IHumanService>();

            
            
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<OrganizationProfile>();
            })).AsSelf().InstancePerRequest();
            
            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            }).As<IMapper>().InstancePerLifetimeScope();
            
            var container = builder.Build();

            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
                 new AutofacWebApiDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            

        }
    }
}
