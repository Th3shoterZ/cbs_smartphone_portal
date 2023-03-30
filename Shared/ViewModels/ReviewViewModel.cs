namespace SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

public class ReviewViewModel
{
    public int ReviewId { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    public int SmartphoneId { get; set; }
    public List<CommentViewModel>? Comments { get; set; }
    public List<RatingViewModel>? Ratings { get; set; }
    public string? UserId { get; set; }
}
