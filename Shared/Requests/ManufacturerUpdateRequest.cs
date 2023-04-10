using System.ComponentModel.DataAnnotations;

namespace SmartphonePortal_Vervoort_Wagner.Shared.Requests;

public class ManufacturerUpdateRequest
{
    public int ManufacturerId { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string LinkToHomePage { get; set; } = string.Empty;
}
