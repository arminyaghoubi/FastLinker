using FastLinker.Application.Resources;
using FluentValidation;

namespace FastLinker.Application.Features.Shortener.Commands;

public class CreateShortLinkCommandValidation : AbstractValidator<CreateShortLinkCommand>
{
    public CreateShortLinkCommandValidation()
    {
        RuleFor(c => c.Url)
            .NotEmpty().WithMessage(ErrorMessageResource.EmptyOrNullUrl)
            .NotNull().WithMessage(ErrorMessageResource.EmptyOrNullUrl)
            .Must(ValidUrl).WithMessage(ErrorMessageResource.InvalidUrl);
    }

    private bool ValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}