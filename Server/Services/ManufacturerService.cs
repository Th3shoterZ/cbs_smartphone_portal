using SmartphonePortal_Vervoort_Wagner.Server.Data;
using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.Requests;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Services;

public class ManufacturerService : IManufacturerService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper<Manufacturer, ManufacturerViewModel> _mapper;

    public ManufacturerService(
        ApplicationDbContext dbContext,
        IMapper<Manufacturer, ManufacturerViewModel> mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public ManufacturerViewModel GetManufacturerById(int id)
    {
        var result = _dbContext.Manufacturers.FirstOrDefault(x => x.ManufacturerId == id);

        return result != null ? _mapper.GetMappedResult(result) : new();
    }

    public List<ManufacturerViewModel> GetAllManufacturers()
    {
        List<ManufacturerViewModel> result = new List<ManufacturerViewModel>();
        foreach (Manufacturer manufacturer in _dbContext.Manufacturers.ToList())
        {
            result.Add(_mapper.GetMappedResult(manufacturer));
        }
        return result;
    }

    public async Task CreateManufacturer(ManufacturerCreationRequest request)
    {
        Manufacturer manufacturer = new Manufacturer
        {
            Name = request.Name,
            Description = request.Description,
            LinkToHomePage = request.LinkToHomePage,
        };
        _dbContext.Manufacturers.Add(manufacturer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateManufacturer(ManufacturerUpdateRequest request)
    {
        var manufacturer = _dbContext.Manufacturers.FirstOrDefault(x => x.ManufacturerId == request.ManufacturerId);

        if (manufacturer == null) return;

        if (!string.IsNullOrEmpty(request.Name))
        {
            manufacturer.Name = request.Name;
        }
        manufacturer.Description = request.Description;
        manufacturer.LinkToHomePage = request.LinkToHomePage;

        await _dbContext.SaveChangesAsync();

    }

    public async Task DeleteManufacturer(int id)
    {
        var manufacturer = _dbContext.Manufacturers.FirstOrDefault(x => x.ManufacturerId.Equals(id));
        if (manufacturer == null || manufacturer.ManufacturerId == 0) return;
        _dbContext.Manufacturers.Remove(manufacturer);
        await _dbContext.SaveChangesAsync();
    }
}
