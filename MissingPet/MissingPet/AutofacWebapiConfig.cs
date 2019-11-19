using Autofac;
using Autofac.Integration.WebApi;
using MissingPet.BLL.Services;
using MissingPet.BLL.Services.Implementations;
using MissingPet.DataAccess.Entities;
using MissingPet.DataAccess.Repositories;
using MissingPet.DataAccess.Repositories.Implementations;
using System.Reflection;
using System.Web.Http;

namespace MissingPet
{
    public class AutofacWebapiConfig
    {
        public static Autofac.IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, Autofac.IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static Autofac.IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<AdvertRepository>()
                   .As<IRepository<Advert>>()
                   .InstancePerRequest();
            builder.RegisterType<AdvertAddressDetailsRepository>()
                   .As<IRepository<AdvertAddressDetails>>()
                   .InstancePerRequest();
            builder.RegisterType<TagRepository>()
                   .As<IRepository<Tag>>()
                   .InstancePerRequest();
            builder.RegisterType<AdvertImageRepository>()
                   .As<IRepository<AdvertImage>>()
                   .InstancePerRequest();
            builder.RegisterType<ContactPersonDetailsRepository>()
                   .As<IRepository<ContactPersonDetails>>()
                   .InstancePerRequest();

            builder.RegisterType<ImageUploadService>()
                   .As<IImageUploadService>()
                   .InstancePerRequest();
            builder.RegisterType<AdvertImageService>()
                   .As<IAdvertImageService>()
                   .InstancePerRequest();

            Container = builder.Build();

            return Container;
        }
    }
}