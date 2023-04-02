using Akanay.Repository.Interfaces;
using Akanay.Repository.Models.EntityFramework;
using Akanay.Service.Interfaces;
using Akanay.Service.Models;
using Autofac;

namespace Akanay.Service.DependencyResolvers.Autofac
{
    public class AutofacServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<EfProductRepository>().As<IProductRepository>();
        }

    }
}
