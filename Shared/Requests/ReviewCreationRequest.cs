using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace SmartphonePortal_Vervoort_Wagner.Shared.Requests;

public class ReviewCreationRequest
{
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Text { get; set; } = string.Empty;
    public int SmartphoneId { get; set; }
    public string UserId { get; set; } = string.Empty;
}
