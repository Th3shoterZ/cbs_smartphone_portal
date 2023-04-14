using SmartphonePortal_Vervoort_Wagner.Server.Data;
using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.Requests;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Services;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper<Category, CategoryViewModel> _mapper;

    public CategoryService(
        ApplicationDbContext dbContext, 
        IMapper<Category, CategoryViewModel> mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public CategoryViewModel GetCategoryById(int id)
    {
        var result = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == id);

        return result != null ? _mapper.GetMappedResult(result) : new();
    }

    public List<CategoryViewModel> GetAllCategories()
    {
        List<CategoryViewModel> result = new List<CategoryViewModel>();
        foreach (Category category in _dbContext.Categories.ToList())
        {
            result.Add(_mapper.GetMappedResult(category));
        }
        return result;
    }
    public async Task CreateCategory(CategoryCreationRequest request)
    {
        Category category = new Category
        {
            Name = request.Name
        };
        _dbContext.Categories.Add(category);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateCategory(CategoryUpdateRequest request)
    {
        var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == request.CategoryId);

        if (category == null) return;

        if (!string.IsNullOrEmpty(request.Name))
        {
            category.Name = request.Name;
        }

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteCategory(int id)
    {
        var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId ==id);
        if (category == null || category.CategoryId == 0) return;
        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync();
    }
}
