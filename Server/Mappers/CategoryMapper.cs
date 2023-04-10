using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Mappers;

public class CategoryMapper : IMapper<Category, CategoryViewModel>
{
    public CategoryViewModel GetMappedResult(Category model)
    {
        return new()
        {
            CategoryId = model.CategoryId,
            Name = model.Name
        };
    }
}
