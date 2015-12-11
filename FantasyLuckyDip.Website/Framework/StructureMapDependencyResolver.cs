using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StructureMap;

namespace FantasyLuckyDip.Website.Framework
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        private readonly IContainer container;

        public StructureMapDependencyResolver(IContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            var instance = this.container.TryGetInstance(serviceType);

            if (instance == null && !serviceType.IsAbstract)
            {
                this.container.Configure(c => c.AddType(serviceType, serviceType));
                instance = this.container.TryGetInstance(serviceType);
            }

            return instance;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.container.GetAllInstances(serviceType).Cast<object>();
        }
    }        
}