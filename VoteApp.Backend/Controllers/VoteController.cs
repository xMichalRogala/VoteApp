using MediatR;
using Microsoft.AspNetCore.Mvc;
using VoteApp.Backend.Core.Commands.Models;
using VoteApp.Backend.Core.Data.Entities;

namespace VoteApp.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoteController : ControllerBase
    {
        private IMediator _mediator;

        public VoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route(nameof(AddVote))]
        [HttpPost]
        public async Task<ActionResult<Vote>> AddVote([FromBody] AddVoteCommand command, CancellationToken ct)
        {
            var result = await _mediator.Send(command, ct);

            return Ok(result);
        }
    }
}
