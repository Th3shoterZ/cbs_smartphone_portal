using SmartphonePortal_Vervoort_Wagner.Server.Data;
using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.Requests;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Services;

public class SmartphoneService : ISmartphoneService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper<Smartphone, SmartphoneViewModel> _mapper;

    public SmartphoneService(
        ApplicationDbContext dbContext,
        IMapper<Smartphone, SmartphoneViewModel> mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public SmartphoneViewModel GetSmartphoneById(int id)
    {
        var phone = _dbContext.Smartphones.FirstOrDefault(x => x.SmartphoneId == id);

        if (phone == null) return new();


        var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId.Equals(phone.CategoryId));
        var manufacturer = _dbContext.Manufacturers.FirstOrDefault(x => x.ManufacturerId.Equals(phone.ManufacturerId));
        var processor = _dbContext.Processors.FirstOrDefault(x => x.ProcessorId.Equals(phone.ProcessorId));

        if (processor != null)
        {
            phone.Processor = processor;
        }
        if (category != null)
        {
            phone.Category = category;
        }
        if (manufacturer != null)
        {
            phone.Manufacturer = manufacturer;
        }

        return _mapper.GetMappedResult(phone);
    }
    public List<SmartphoneViewModel> GetSmartphoneAllSmartphones()
    {
        List<SmartphoneViewModel> phones = new();
        foreach (Smartphone smartphone in _dbContext.Smartphones.ToList())
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId.Equals(smartphone.CategoryId));
            var manufacturer = _dbContext.Manufacturers.FirstOrDefault(x => x.ManufacturerId.Equals(smartphone.ManufacturerId));
            var processor = _dbContext.Processors.FirstOrDefault(x => x.ProcessorId.Equals(smartphone.ProcessorId));

            if (processor != null)
            {
                smartphone.Processor = processor;
            }
            if (category != null)
            {
                smartphone.Category = category;
            }
            if (manufacturer != null)
            {
                smartphone.Manufacturer = manufacturer;
            }

            phones.Add(_mapper.GetMappedResult(smartphone));
        }
        return phones;
    }

    public async Task CreateSmartphone(SmartphoneCreationRequest request)
    {

        // TODO handle pictures

        var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId.Equals(request.CategoryId));
        var manufacturer = _dbContext.Manufacturers.FirstOrDefault(x => x.ManufacturerId.Equals(request.ManufacturerId));
        var processor = _dbContext.Processors.FirstOrDefault(x => x.ProcessorId.Equals(request.ProcessorId));

        if (processor == null || manufacturer == null || category == null)
        {
            throw new Exception("null constraints not met");
        }
        var sm = new Smartphone()
        {
            Name = request.Name ?? string.Empty,
            Description = request.Description ?? string.Empty,
            DisplaySize = request.DisplaySize,
            Weight = request.Weight,
            Resolution = request.Resolution ?? string.Empty,
            Manufacturer = manufacturer ?? new(),
            Processor = processor ?? new(),
            Category = category ?? new(),
        };
        _dbContext.Smartphones.Add(sm);

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateSmartphone(SmartphoneUpdateRequest request)
    {

        // TODO handle pictures

        var smartphone = _dbContext.Smartphones.FirstOrDefault(x => x.SmartphoneId.Equals(request.SmartphoneId));

        if (smartphone == null || smartphone.SmartphoneId == 0) return;

        var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId.Equals(smartphone.CategoryId));
        var manufacturer = _dbContext.Manufacturers.FirstOrDefault(x => x.ManufacturerId.Equals(smartphone.ManufacturerId));
        var processor = _dbContext.Processors.FirstOrDefault(x => x.ProcessorId.Equals(smartphone.ProcessorId));

        if (category == null || category.CategoryId != request.CategoryId)
        {
            var tempCategory = _dbContext.Categories.FirstOrDefault(x => x.CategoryId.Equals(request.CategoryId));
            if (tempCategory != null)
            {
                smartphone.Category = tempCategory;
            }
        }
        if (manufacturer == null || manufacturer.ManufacturerId != request.ManufacturerId)
        {
            var tempManufacturer = _dbContext.Manufacturers.FirstOrDefault(x => x.ManufacturerId.Equals(request.CategoryId));
            if (tempManufacturer != null)
            {
                smartphone.Manufacturer = tempManufacturer;
            }
        }
        if (processor == null || processor.ProcessorId != request.ProcessorId)
        {
            var tempProcessor = _dbContext.Processors.FirstOrDefault(x => x.ProcessorId.Equals(request.ProcessorId));
            if (tempProcessor != null)
            {
                smartphone.Processor = tempProcessor;
            }
        }

        if (!string.IsNullOrEmpty(request.Name))
        {
            smartphone.Name = request.Name;
        }
        if (!string.IsNullOrEmpty(request.Description))
        {
            smartphone.Description = request.Description;
        }

        smartphone.DisplaySize = request.DisplaySize;
        smartphone.Weight = request.Weight;
        smartphone.Resolution = request.Resolution;

        await _dbContext.SaveChangesAsync();
    }


    public async Task DeleteSmartphone(int id)
    {
        var smartphone = _dbContext.Smartphones.FirstOrDefault(x => x.SmartphoneId.Equals(id));
        if (smartphone == null || smartphone.ProcessorId == 0) return;
        _dbContext.Smartphones.Remove(smartphone);
        await _dbContext.SaveChangesAsync();
    }
}
