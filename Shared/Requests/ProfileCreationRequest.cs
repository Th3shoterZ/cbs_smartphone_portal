using System.ComponentModel.DataAnnotations;

namespace SmartphonePortal_Vervoort_Wagner.Shared.Requests;

public class ProfileCreationRequest
{

    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required]
    public string Role { get; set; } = string.Empty;
}
