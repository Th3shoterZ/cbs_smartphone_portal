using Microsoft.AspNetCore.Mvc;
using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Shared.Requests;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ManufacturerController : ControllerBase
{
    private readonly IManufacturerService _manufacturerService;

    public ManufacturerController(IManufacturerService manufacturerService)
    {
        _manufacturerService = manufacturerService;
    }

    /// <summary>
    /// Get a manufacturer by Id
    /// </summary>
    /// <param name="manufacturerId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{manufacturerId}")]
    public ActionResult<ManufacturerViewModel> GetCategory(int manufacturerId)
    {
        try
        {
            ManufacturerViewModel result = _manufacturerService.GetManufacturerById(manufacturerId);
            return Ok(result);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Get all manufacturers
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("all")]
    public ActionResult<List<ManufacturerViewModel>> GetAllCategories()
    {
        try
        {
            var result = _manufacturerService.GetAllManufacturers();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    /// <summary>
    /// Create a manufacturer
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult> CreateCategory(ManufacturerCreationRequest request)
    {
        try
        {
            await _manufacturerService.CreateManufacturer(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Update a manufacturer
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("update")]
    public async Task<ActionResult> UpdateCategory(ManufacturerUpdateRequest request)
    {
        try
        {
            await _manufacturerService.UpdateManufacturer(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Delete a manufacturer by Id
    /// </summary>
    /// <param name="manufacturerId"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{manufacturerId}")]
    public async Task<ActionResult> DeleteCategory(int manufacturerId)
    {
        try
        {
            await _manufacturerService.DeleteManufacturer(manufacturerId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
