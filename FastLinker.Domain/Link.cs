using FastLinker.Domain.Common;

namespace FastLinker.Domain;

public class Link : BaseEntity
{
    public string Url { get; set; } = string.Empty;
}