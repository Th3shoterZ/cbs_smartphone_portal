namespace SmartphonePortal_Vervoort_Wagner.Server.Models;

public class Review
{
    public int ReviewId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public int SmartphoneId { get; set; }
    public Smartphone Smartphone { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
    public List<Rating> Ratings { get; set; } = new();
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public ApplicationUser User { get; set; } = new();
}