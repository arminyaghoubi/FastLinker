using FastLinker.API.Controllers.Common;
using FastLinker.Application.Features.Shortener.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FastLinker.API.Controllers;

public class ShortenerController : BaseController
{
    public ShortenerController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<ActionResult> CreateShortKey(CreateShortLinkCommand command, CancellationToken cancellation)
    {
        var result = await _mediator.Send(command, cancellation);
        return Ok(result);
    }
}
