namespace SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

public class CommentViewModel
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public int ReviewId { get; set; }
}
