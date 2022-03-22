using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using System.Threading.Tasks;
using XMLProcessor.Server.Application.Commands;

namespace XMLProcessor.Server.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class XMLProcessController : BaseApiController
    {
        private readonly IMediator _mediator;

        public XMLProcessController(IMediator iMediator) => _mediator = iMediator ?? throw new ArgumentNullException(nameof(iMediator));

        [Route("Process")]
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Process([FromBody] NodeProcessCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

    }
}
