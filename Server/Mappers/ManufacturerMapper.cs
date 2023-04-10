using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Mappers;

public class ManufacturerMapper : IMapper<Manufacturer, ManufacturerViewModel>
{
    public ManufacturerViewModel GetMappedResult(Manufacturer model)
    {
        return new()
        {
            ManufacturerId = model.ManufacturerId,
            Description = model.Description,
            LinkToHomePage = model.LinkToHomePage,
            Name = model.Name
        };
    }
}
