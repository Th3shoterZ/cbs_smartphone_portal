using SmartphonePortal_Vervoort_Wagner.Shared.Requests;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Interfaces;

public interface IManufacturerService
{
    ManufacturerViewModel GetManufacturerById(int id);
    List<ManufacturerViewModel> GetAllManufacturers();
    Task CreateManufacturer(ManufacturerCreationRequest request);
    Task UpdateManufacturer(ManufacturerUpdateRequest request);
    Task DeleteManufacturer(int id);
}
