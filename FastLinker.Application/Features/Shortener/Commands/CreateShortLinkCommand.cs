using FluentValidation;
using MediatR;

namespace FastLinker.Application.Features.Shortener.Commands;

public class CreateShortLinkCommand : IRequest<string>
{
    public string? Title { get; set; }
    public string Url { get; set; } = string.Empty;
}