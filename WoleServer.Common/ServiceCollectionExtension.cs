using System;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace WoleServer.Common
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Add dryIoc service container.
        /// </summary>
        /// <typeparam name="TCompositionRoot">Type of the boostrapper you want to use</typeparam>
        /// <param name="services">Current service collection</param>
        /// <returns>Service provider to return in ConfigureServices method</returns>
        public static IServiceProvider AddDryIoc<TCompositionRoot>(this IServiceCollection services)
        {
            var container = new Container().WithDependencyInjectionAdapter(services);

            container.RegisterMany<TCompositionRoot>();
            container.Resolve<TCompositionRoot>();

            return container.Resolve<IServiceProvider>();
        }
    }
}