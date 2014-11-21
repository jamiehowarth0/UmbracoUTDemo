using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace UmbracoCI.Extensions
{
    [ExcludeFromCodeCoverage]
    public class UmbracoWebApiHttpControllerActivator : IHttpControllerActivator
    {

        private readonly DefaultHttpControllerActivator _defaultHttpControllerActivator;

        public UmbracoWebApiHttpControllerActivator()
        {
            this._defaultHttpControllerActivator = new DefaultHttpControllerActivator();
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            IHttpController instance =
                this.IsUmbracoController(controllerType)
                    ? Activator.CreateInstance(controllerType) as IHttpController
                    : this._defaultHttpControllerActivator.Create(request, controllerDescriptor, controllerType);

            return instance;
        }

        private bool IsUmbracoController(Type controllerType)
        {
            return controllerType.Namespace != null
                && controllerType.Namespace.StartsWith("umbraco", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
