using PropertyHub.Domain.Common;
using PropertyHub.Domain.Enums;
namespace PropertyHub.Domain.Entities;

public class PropertyVisit : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public Guid PropertyId { get; set; }
    public Property Property { get; set; } = null!;
    public DateTime ScheduledAt { get; set; }
    public VisitStatus Status { get; set; }
    public string? CustomerNote { get; set; }
    public string? AgentNote { get; set; }

}