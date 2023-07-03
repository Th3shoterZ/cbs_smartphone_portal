using System.ComponentModel.DataAnnotations;

namespace SmartphonePortal_Vervoort_Wagner.Shared.Requests;

public class PictureCreationRequest
{
    [Required]
    public int SmartphoneId { get; set; }
}
