using System.ComponentModel.DataAnnotations;

namespace SmartphonePortal_Vervoort_Wagner.Shared.Requests;

public class ReviewUpdateRequest
{
    public int ReviewId { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Text { get; set; } = string.Empty;
    public int SmartphoneId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int Rating { get; set; }
}

