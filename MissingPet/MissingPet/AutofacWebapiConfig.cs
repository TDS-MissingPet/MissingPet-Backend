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
                   .As<IRepository<AdvertEntity>>()
                   .InstancePerRequest();
            builder.RegisterType<AdvertAddressDetailsRepository>()
                   .As<IRepository<AdvertAddressDetailsEntity>>()
                   .InstancePerRequest();
            builder.RegisterType<TagRepository>()
                   .As<IRepository<TagEntity>>()
                   .InstancePerRequest();
            builder.RegisterType<AdvertImageRepository>()
                   .As<IRepository<AdvertImageEntity>>()
                   .InstancePerRequest();
            builder.RegisterType<AccountRepository>()
                   .As<IRepository<AccountEntity>>()
                   .InstancePerRequest();
            builder.RegisterType<AccountPhoneNumberRepository>()
                   .As<IRepository<AccountPhoneNumberEntity>>()
                   .InstancePerRequest();

            builder.RegisterType<ImageUploadService>()
                   .As<IImageUploadService>()
                   .InstancePerRequest();
            builder.RegisterType<AdvertImageService>()
                   .As<IAdvertImageService>()
                   .InstancePerRequest();
            builder.RegisterType<AccountService>()
                   .As<IAccountService>()
                   .InstancePerRequest();
            builder.RegisterType<AdvertService>()
                   .As<IAdvertService>()
                   .InstancePerRequest();
            builder.RegisterType<TagService>()
                   .As<ITagService>()
                   .InstancePerRequest();

            Container = builder.Build();

            return Container;
        }
    }
}