using MediatR;

namespace FastLinker.Application.Features.Shortener.Commands;

public class CreateShortLinkCommandHandler : IRequestHandler<CreateShortLinkCommand, string>
{
    Task<string> IRequestHandler<CreateShortLinkCommand, string>.Handle(CreateShortLinkCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}