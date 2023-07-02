using System.ComponentModel.DataAnnotations;

namespace SmartphonePortal_Vervoort_Wagner.Shared.Requests;

public class PictureCreationRequest
{
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public int SmartphoneId { get; set; }
}
