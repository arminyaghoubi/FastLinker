using FastLinker.Application.Resources;

namespace FastLinker.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string shortKey) : base(string.Format(ErrorMessageResource.ShortKeyNotFound, shortKey))
    {
    }
}
