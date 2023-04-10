namespace SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

public class ProfileViewModel
{
    public string Id { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public List<CommentViewModel> Comments { get; set; } = new();
    public List<RatingViewModel> Ratings { get; set; } = new();
    public List<ReviewViewModel> Reviews { get; set; } = new();
}
