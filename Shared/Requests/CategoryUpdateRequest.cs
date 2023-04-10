using System.ComponentModel.DataAnnotations;

namespace SmartphonePortal_Vervoort_Wagner.Shared.Requests;

public class CategoryUpdateRequest
{
    public int CategoryId { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
}
