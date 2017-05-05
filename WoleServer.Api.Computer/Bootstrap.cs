using DryIoc;
using Microsoft.AspNetCore.Hosting;
using WoleServer.Api.Computer.Domain.Services;
using WoleServer.Api.Computer.Domain.Services.Abstractions;

namespace WoleServer.Api.Computer
{
    public class Bootstrap
    {
        public Bootstrap(IContainer container, IHostingEnvironment env)
        {
            if (env.IsDevelopment() || env.IsEnvironment("Testing")) // Injections specifics to dev & testing platforms.
            {
                container.Register<IComputerService, InMemoryComputerService>(reuse: Reuse.Singleton);
            }
        }
    }
}