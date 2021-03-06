﻿using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace Creuna.Basis.Revisited.Web.App_Start.Structuremap
{
    // NOTE: simplified version of 'StructureMapDependencyScope' from 'StructureMap.MVC4' project
    // https://github.com/webadvanced/Structuremap.MVC4/blob/master/content/DependencyResolution/StructureMapDependencyScope.cs.pp
    public class StructureMapDependencyScope : IDependencyScope
    {
        protected readonly IContainer Container;

        public StructureMapDependencyScope(IContainer container)
        {
            Container = container;
        }

        public object GetService(Type serviceType)
        {
            return serviceType.IsAbstract || serviceType.IsInterface
                ? Container.TryGetInstance(serviceType)
                : Container.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Container.GetAllInstances(serviceType).Cast<object>();
        }

        public void Dispose()
        {
            Container.Dispose();
        }
    }
}