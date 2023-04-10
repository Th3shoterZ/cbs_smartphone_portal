namespace SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

public class ReviewViewModel
{
    public int ReviewId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public int SmartphoneId { get; set; }
    public List<CommentViewModel> Comments { get; set; } = new();
    public int Rating { get; set; }
    public string UserId { get; set; } = string.Empty;
}
