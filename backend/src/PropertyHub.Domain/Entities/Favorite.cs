using PropertyHub.Domain.Common;
namespace PropertyHub.Domain.Entities;

public class Favorite : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public Guid PropertyId { get; set; }
    public Property Property { get; set; } = null!;
}