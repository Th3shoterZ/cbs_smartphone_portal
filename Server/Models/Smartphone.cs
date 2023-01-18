namespace SmartphonePortal_Vervoort_Wagner.Server.Models;

public class Smartphone
{
    public int? SmartphoneId { get; set; }
    public string? Name { get; set; }
    public string? Category { get; set; }
    public PhoneDetails? PhoneDetails { get; set; }
    public List<Rating>? Ratings { get; set; }
    public List<Review>? Reviews { get; set; }
}
