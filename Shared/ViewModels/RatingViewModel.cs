namespace SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

public class RatingViewModel
{
    public int RatingId { get; set; }
    public int Stars { get; set; }
    public int SmartphoneId { get; set; }
    public string? UserId { get; set; }
    public ReviewViewModel? Review { get; set; }
}
