using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Http;
using System.Web.Mvc;
using PizzaBOT.Context.DishRepository;
using PizzaBOT.Context;
using System.Reflection;

namespace PizzaBOT.Autofac
{
    public class AutoFacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<DishRepository>().As<IDishRepository>().WithParameter("dataContext", new DataContext());
            //builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().WithParameter("context", new DataContext());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}