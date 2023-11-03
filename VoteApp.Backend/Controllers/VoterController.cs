using MediatR;
using Microsoft.AspNetCore.Mvc;
using VoteApp.Backend.Core.Commands.Models;
using VoteApp.Backend.Core.Data.Entities;
using VoteApp.Backend.Core.Queries.Models;

namespace VoteApp.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoterController : ControllerBase
    {
        private IMediator _mediator;

        public VoterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route(nameof(GetAll))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voter>>> GetAll(CancellationToken ct)
        {
            var result = await _mediator.Send(new GetAllVotersQuery(), ct);

            return Ok(result);
        }

        [Route(nameof(AddVoter))]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Voter>>> AddVoter([FromBody] AddVoterCommand command,CancellationToken ct)
        {
            var result = await _mediator.Send(command, ct);

            return Ok(result);
        }
    }
}
