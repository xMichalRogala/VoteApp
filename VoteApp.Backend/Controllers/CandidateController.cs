using MediatR;
using Microsoft.AspNetCore.Mvc;
using VoteApp.Backend.Core.Commands.Models;
using VoteApp.Backend.Core.Data.Entities;
using VoteApp.Backend.Core.Queries.Models;

namespace VoteApp.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private IMediator _mediator;

        public CandidateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route(nameof(GetAll))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetAll(CancellationToken ct)
        {
            var result = await _mediator.Send(new GetAllCandidatesQuery(), ct);

            return Ok(result);
        }

        [Route(nameof(AddCandidate))]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Voter>>> AddCandidate([FromBody] AddCandidateCommand command, CancellationToken ct)
        {
            var result = await _mediator.Send(command, ct);

            return Ok(result);
        }
    }
}
