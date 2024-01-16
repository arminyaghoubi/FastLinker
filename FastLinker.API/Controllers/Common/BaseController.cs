using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FastLinker.API.Controllers.Common;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController : ControllerBase
{
    protected readonly IMediator _mediator;

    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
