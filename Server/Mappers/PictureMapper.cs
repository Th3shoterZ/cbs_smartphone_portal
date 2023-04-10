using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Mappers;

public class PictureMapper : IMapper<Picture, PictureViewModel>
{
    public PictureViewModel GetMappedResult(Picture model)
    {
        return new()
        {
            PathToData = model.PathToData ?? string.Empty,
            SmartphoneId = model.SmartphoneId,
            PictureId = model.PictureId,
            Title = model.Title ?? string.Empty
        };
    }
}
