// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StructuremapMvc.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Mvc;
using HowShop.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using SolidR.Core;
using SolidR.Core.Mvc.DependencyResolution;
using StructureMap;
using WebActivatorEx;
using StructureMapScopeModule = HowShop.Web.Boot.StructureMapScopeModule;

[assembly: PreApplicationStartMethod(typeof(StructureMapMvc), "Start")]
[assembly: ApplicationShutdownMethod(typeof(StructureMapMvc), "End")]

namespace HowShop.Web {
    public static class StructureMapMvc
    {

        public static StructureMapDependencyScope StructureMapDependencyScope { get; set; }

		public static void End()
        {
            StructureMapDependencyScope.Dispose();
        }
		
        public static void Start()
        {
            App.Initialize(cfg =>
            {
                cfg.Scan(scan =>
                {
                    scan.AssembliesFromApplicationBaseDirectory();
                    scan.WithDefaultConventions();
                    scan.LookForRegistries();
                });
            });

            IContainer container = App.Container;
            
            StructureMapDependencyScope = new StructureMapDependencyScope(container);
            DependencyResolver.SetResolver(StructureMapDependencyScope);
            DynamicModuleUtility.RegisterModule(typeof(StructureMapScopeModule));
        }
    }
}