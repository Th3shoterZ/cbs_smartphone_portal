namespace SmartphonePortal_Vervoort_Wagner.Server.Models;

public class Comment
{
    public int CommentId { get; set; }
    public string Text { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser User { get; set; } = new();
    public Review Review { get; set; } = new();
}