using System.ComponentModel.DataAnnotations;

namespace SmartphonePortal_Vervoort_Wagner.Shared.Requests;

public  class CategoryCreationRequest
{
    [Required]
    public string Name { get; set; } = string.Empty;
}
