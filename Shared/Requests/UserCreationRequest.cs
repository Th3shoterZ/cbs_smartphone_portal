using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Shared.Requests;

public class UserCreationRequest : UserViewModel
{
    public string Password { get; set; } = string.Empty;
}
