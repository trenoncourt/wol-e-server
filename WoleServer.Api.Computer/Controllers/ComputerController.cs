using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using WoleServer.Api.Computer.Domain.Services.Abstractions;
using WoleServer.Api.Computer.Dtos;
using WoleServer.Api.Computer.Domain.Models;

namespace WoleServer.Api.Computer.Controllers
{
    /// <summary>
    /// Rest endpoint for computers.
    /// </summary>
    [Route("api/computers")]
    public class ComputerController
    {
        [HttpGet]
        public IActionResult Get([FromServices] IComputerService computerService, [FromServices] IMapper mapper)
        {
            IEnumerable<Domain.Models.Computer> computers = computerService.Get();
            var computersDto = mapper.Map<IEnumerable<GetComputersResult>>(computers);

            return new OkObjectResult(computersDto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PostComputerRequest postComputerDto,
            [FromServices] IComputerService computerService,
            [FromServices] IMapper mapper)
        {
            var computer = mapper.Map<Domain.Models.Computer>(postComputerDto);
            computerService.Add(computer);

            return new NoContentResult();
        }
    }
}