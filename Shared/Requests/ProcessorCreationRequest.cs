using System.ComponentModel.DataAnnotations;

namespace SmartphonePortal_Vervoort_Wagner.Shared.Requests;

public class ProcessorCreationRequest
{
    [Required]
    public string Gigaherz { get; set; } = string.Empty;
    [Required]
    public int CoreCount { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
}
