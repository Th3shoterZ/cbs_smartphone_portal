using Microsoft.AspNetCore.Mvc;
using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Shared.Requests;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    /// <summary>
    /// Get a category by Id
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{categoryId}")]
    public ActionResult<CategoryViewModel> GetCategory(int categoryId)
    {
        try
        {
            CategoryViewModel result = _categoryService.GetCategoryById(categoryId);
            return Ok(result);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Get all categories (alls coz issue with using just "all")
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("alls")]
    public ActionResult<List<CategoryViewModel>> GetAllCategories()
    {
        try
        {
            var result = _categoryService.GetAllCategories();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    /// <summary>
    /// Create a category
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult> CreateCategory(CategoryCreationRequest request)
    {
        try
        {
            await _categoryService.CreateCategory(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Update a category
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("update")]
    public async Task<ActionResult> UpdateCategory(CategoryUpdateRequest request)
    {
        try
        {
            await _categoryService.UpdateCategory(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Delete a category by Id
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{categoryId}")]
    public async Task<ActionResult> DeleteCategory(int categoryId)
    {
        try
        {
            await _categoryService.DeleteCategory(categoryId);
            return Ok();

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
