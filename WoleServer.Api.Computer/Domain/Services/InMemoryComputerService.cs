using System.Collections.Generic;
using WoleServer.Api.Computer.Domain.Services.Abstractions;
using WoleServer.Api.Computer.Domain.Models;

namespace WoleServer.Api.Computer.Domain.Services
{
    public class InMemoryComputerService : IComputerService
    {
        private static readonly List<Models.Computer> Computers = new List<Models.Computer>();
        
        public IEnumerable<Models.Computer> Get()
        {
            return Computers;
        }

        public void Add(Models.Computer computer)
        {
            computer.Id = Computers.Count + 1;
            Computers.Add(computer);
        }
    }
}