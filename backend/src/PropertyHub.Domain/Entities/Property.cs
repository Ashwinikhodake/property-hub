using PropertyHub.Domain.Common;
using PropertyHub.Domain.Enums;

namespace PropertyHub.Domain.Entities;

public class Property : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public PropertyType PropertyType { get; set; }
    public ListingType ListingType { get; set; }
    public PropertyStatus Status { get; set; }
    public int? Bedrooms { get; set; }
    public int? Bathrooms { get; set; }
    public decimal? AreaInSquareFeet { get; set; }
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public Guid AgentId { get; set; }
    public User Agent { get; set; } = null!;
    public ICollection<PropertyImage> Images { get; set; } = new List<PropertyImage>();
    public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    public ICollection<PropertyVisit> Visits { get; set; } = new List<PropertyVisit>();


}