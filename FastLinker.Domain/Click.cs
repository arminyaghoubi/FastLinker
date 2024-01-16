using FastLinker.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastLinker.Domain;

public class Click : BaseEntity
{
    public string Ip { get; set; } = string.Empty;

    [ForeignKey("ShortLink")]
    public int ShortLinkId { get; set; }
    public ShortLink? ShortLink { get; set; }
}
