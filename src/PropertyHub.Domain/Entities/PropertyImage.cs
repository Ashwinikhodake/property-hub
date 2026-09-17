using PropertyHub.Domain.Common;
namespace PropertyHub.Domain.Entities;

public class PropertyImage : BaseEntity
{
    public Guid PropertyId { get; set; }
    public Property Property { get; set; } = null!;
    public string ImageUrl { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }
}