using PropertyHub.Domain.Common;
using PropertyHub.Domain.Enums;

namespace PropertyHub.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public ICollection<Property> Properties { get; set; } = new List<Property>();
    public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    public ICollection<PropertyVisit> PropertyVisits { get; set; } = new List<PropertyVisit>();
}