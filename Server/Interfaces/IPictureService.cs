using SmartphonePortal_Vervoort_Wagner.Shared.Responses;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Interfaces;

public interface IPictureService
{
    PictureViewModel GetPictureById(int pictureId);
    List<PictureViewModel> GetPicturesForSmartphone(int smartphoneId);
    List<PictureViewModel> GetAllPictures();

    Task<List<FileUploadResponse>> AddPicture(IEnumerable<IFormFile> files, int smartphoneId);
    Task<List<FileUploadResponse>> UpdatePicture(IEnumerable<IFormFile> files, int smartphoneId, int pictureId);
    Task DeletePicture(int pictureId);
}
