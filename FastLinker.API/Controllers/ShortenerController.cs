using FastLinker.API.Controllers.Common;
using FastLinker.Application.Features.Shortener.Commands;
using FastLinker.Application.Features.Shortener.Queries.GetOriginalUrl;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FastLinker.API.Controllers;

public class ShortenerController : BaseController
{
    public ShortenerController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<ActionResult> CreateShortKey([FromBody] CreateShortLinkCommand command, CancellationToken cancellation)
    {
        var result = await _mediator.Send(command, cancellation);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> GetOrginalUrl([FromQuery] string shortKey, CancellationToken cancellation)
    {
        var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
        GetOriginalUrlQuery query = new(shortKey, ip);
        var result = await _mediator.Send(query, cancellation);
        return Ok(result);
    }
}
