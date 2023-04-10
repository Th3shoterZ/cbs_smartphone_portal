using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace SmartphonePortal_Vervoort_Wagner.Shared.Requests;

public class SmartphoneUpdateRequest
{
    public int SmartphoneId { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public int ManufacturerId { get; set; }
    [Required]
    public int ProcessorId { get; set; }
    public double DisplaySize { get; set; }
    public string Resolution { get; set; } = string.Empty;
    public double Weight { get; set; }
    public int Rating { get; set; }
    public List<PictureViewModel> Pictures { get; set; } = new();
}
