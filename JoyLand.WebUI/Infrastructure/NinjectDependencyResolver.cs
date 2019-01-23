using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoyLand.Domain.Abstract;
using JoyLand.Domain.Entities;
using Moq;
using JoyLand.Domain.Concrete;
using JoyLand.Domain;
using System.Configuration;
using JoyLand.WebUI.Infrastructure.Abstract;
using JoyLand.WebUI.Infrastructure.Concrete;


namespace JoyLand.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<ISweetRepository>().To<EFSweetRepository>();
            kernel.Bind<ICategoryRepository>().To<EFCategoryRepository>();
            kernel.Bind<ISDRepository>().To<EFShoppingDetailsRepository>();
            kernel.Bind<IAuthProvider>().To<FormAuthProvider>();
        }
    }
}