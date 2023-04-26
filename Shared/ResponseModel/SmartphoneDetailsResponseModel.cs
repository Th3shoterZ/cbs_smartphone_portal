using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Shared.ResponseModel;

public class SmartphoneDetailsResponseModel
{
    public SmartphoneViewModel Smartphone { get; set; } = new();
    public List<ReviewViewModel> Reviews { get; set; } = new List<ReviewViewModel>();
    public ReviewViewModel? UserReview { get; set; }
}
