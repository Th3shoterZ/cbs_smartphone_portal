using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Mappers;

public class SmartphoneMapper : IMapper<Smartphone, SmartphoneViewModel>
{
    private readonly IMapper<Category, CategoryViewModel> _categoryMapper;
    private readonly IMapper<Manufacturer, ManufacturerViewModel> _manufacturerMapper;
    private readonly IMapper<Processor, ProcessorViewModel> _processorMapper;
    private readonly IMapper<Picture, PictureViewModel> _pictureMapper;

    public SmartphoneMapper(
        IMapper<Category, CategoryViewModel> categoryMapper,
        IMapper<Manufacturer, ManufacturerViewModel> manufacturerMapper,
        IMapper<Processor, ProcessorViewModel> processorMapper,
        IMapper<Picture, PictureViewModel> pictureMapper)
    {
        _categoryMapper = categoryMapper;
        _manufacturerMapper = manufacturerMapper;
        _processorMapper = processorMapper;
        _pictureMapper = pictureMapper;
    }

    public SmartphoneViewModel GetMappedResult(Smartphone model)
    {
        SmartphoneViewModel result = new()
        {
            SmartphoneId = model.SmartphoneId,
            Description = model.Description ?? string.Empty,
            DisplaySize = model.DisplaySize,
            Name = model.Name ?? string.Empty,
            Resolution = model.Resolution ?? string.Empty,
            Weight = model.Weight,
        };

        if (model.Category != null)
        {
            result.Category = _categoryMapper.GetMappedResult(model.Category);
        }

        if (model.Ratings != null && model.Ratings.Count > 0)
        {
            List<int> stars = ((List<int>)(from Stars in model.Ratings
                                           select Stars));
            result.Rating = (int)stars.Average();
        }

        if (model.Manufacturer != null)
        {
            result.Manufacturer = _manufacturerMapper.GetMappedResult(model.Manufacturer);
        }

        if (model.Processor != null)
        {
            result.Processor = _processorMapper.GetMappedResult(model.Processor);
        }

        if (model.Pictures != null)
        {
            foreach (var pic in model.Pictures)
            {
                result.Pictures.Add(_pictureMapper.GetMappedResult(pic));
            }
        }

        return result;
    }
}
