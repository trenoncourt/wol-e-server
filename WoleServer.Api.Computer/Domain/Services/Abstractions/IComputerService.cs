using System.Collections.Generic;

namespace WoleServer.Api.Computer.Domain.Services.Abstractions
{
    public interface IComputerService
    {
        IEnumerable<Models.Computer> Get();

        void Add(Models.Computer computer);
    }
}