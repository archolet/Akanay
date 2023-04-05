<<<<<<< HEAD
﻿using Akanay.Core.Utilities.Interceptors;
using Akanay.Core.Utilities.Security.Jwt;
=======
﻿using Akanay.Core.Utilities.Security.Jwt;
>>>>>>> d1e71ae5530256531d2e3672820f5c226d710df2
using Akanay.Repository.Interfaces;
using Akanay.Repository.Interfaces.CustomUser;
using Akanay.Repository.Models.EntityFramework;
using Akanay.Repository.Models.EntityFramework.CustomUser;
using Akanay.Service.Interfaces;
using Akanay.Service.Interfaces.CustomUser;
using Akanay.Service.Models;
using Akanay.Service.Models.CustomUser;
using Autofac;
using Autofac.Extras.DynamicProxy;

namespace Akanay.Service.DependencyResolvers.Autofac
{
    public class AutofacServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<EfProductRepository>().As<IProductRepository>();

            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<EfCategoryRepository>().As<ICategoryRepository>();


            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<EfUserRepository>().As<IUserRepository>();

            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();


<<<<<<< HEAD
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


=======
>>>>>>> d1e71ae5530256531d2e3672820f5c226d710df2
        }

    }
}
