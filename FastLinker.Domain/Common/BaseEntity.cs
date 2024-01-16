namespace FastLinker.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreationDateTime { get; set; }
}
