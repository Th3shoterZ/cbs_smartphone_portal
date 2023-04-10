using SmartphonePortal_Vervoort_Wagner.Shared.Requests;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Interfaces;

public interface ISmartphoneService
{
    SmartphoneViewModel GetSmartphoneById(int id);
    List<SmartphoneViewModel> GetSmartphoneAllSmartphones();
    Task CreateSmartphone(SmartphoneCreationRequest request);
    Task UpdateSmartphone(SmartphoneUpdateRequest request);
    Task DeleteSmartphone(int id);
}
