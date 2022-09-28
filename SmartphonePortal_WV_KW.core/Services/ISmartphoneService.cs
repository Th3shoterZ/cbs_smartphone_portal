using SmartphonePortal_WV_KW.Shared.ViewModels;

namespace SmartphonePortal_WV_KW.core.Services
{
    public interface ISmartphoneService
    {
        List<SmartphoneViewModel> GetSmartphones();
    }
}
