using System.ComponentModel.DataAnnotations;

namespace SmartphonePortal_Vervoort_Wagner.Shared.Requests;

public class ProfileUpdateRequest
{
    public string ProfileId { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Role { get; set; } = string.Empty;
}
