using FastLinker.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastLinker.Domain;

public class ShortLink : BaseEntity
{
    public string? Title { get; set; }
    public string ShortKey { get; set; } = string.Empty;

    [ForeignKey("Link")]
    public int LinkId { get; set; }
    public Link? Link { get; set; }
}
