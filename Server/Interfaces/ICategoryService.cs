using SmartphonePortal_Vervoort_Wagner.Shared.Requests;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Interfaces;

public interface ICategoryService
{
    CategoryViewModel GetCategoryById(int id);
    List<CategoryViewModel> GetAllCategories();
    Task CreateCategory(CategoryCreationRequest request);
    Task UpdateCategory(CategoryUpdateRequest request);
    Task DeleteCategory(int id);
}
