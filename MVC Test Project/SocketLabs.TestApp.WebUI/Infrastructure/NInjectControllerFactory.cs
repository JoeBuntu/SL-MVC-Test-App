 using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using SocketLabs.TestApp.Domain.Abstract;
using SocketLabs.TestApp.Domain.Concrete;

namespace SocketLabs.TestApp.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory 
    {
        private IKernel _NInjectKernel;
        public NinjectControllerFactory() 
        {
            _NInjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) 
        { 
            return controllerType == null ? null : (IController)_NInjectKernel.Get(controllerType);
        }

        private void AddBindings() 
        {
            _NInjectKernel.Bind<ILoginProvider>().To<SqlCeLoginProvider>();
            _NInjectKernel.Bind<IUserRepository>().To<EFUserRepository>();
        }
    }
}
