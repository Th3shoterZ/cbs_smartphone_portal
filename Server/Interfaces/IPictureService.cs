using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Interfaces;

public interface IPictureService
{
    List<PictureViewModel> GetAllPictures();
}
