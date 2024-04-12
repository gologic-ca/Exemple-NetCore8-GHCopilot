using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Conduit.Features.Tags;

[Route("PrimerNumbers")]
public class PrimerNumberController( IMediator mediator) : Controller
{
    [HttpGet("{start}-{end}")]
    public Task<PrimerNumbersEnvelope> GetPrimerNumbers(int start, int end, CancellationToken cancellationToken) =>
        mediator.Send(new PrimerNumbersQuery(start, end), cancellationToken);
}
