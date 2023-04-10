namespace SmartphonePortal_Vervoort_Wagner.Server.Models;

public class Rating
{
    public int RatingId { get; set; }
    public int Stars { get; set; }
    public int SmartphoneId { get; set; }
    public Smartphone Smartphone { get; set; } = new();
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser User { get; set; } = new();
    public Review Review { get; set; } = new();
}