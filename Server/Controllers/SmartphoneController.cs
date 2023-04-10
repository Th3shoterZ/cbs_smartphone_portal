using Microsoft.AspNetCore.Mvc;
using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Shared.Requests;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class SmartphoneController : ControllerBase
{
    private readonly ISmartphoneService _smartphoneService;
    public SmartphoneController(ISmartphoneService smartphoneService)
    {
        _smartphoneService = smartphoneService;
    }

    /// <summary>
    /// Get a smartphone by Id
    /// </summary>
    /// <param name="smartphoneId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{smartphoneId}")]
    public ActionResult<SmartphoneViewModel> GetProcessor(int smartphoneId)
    {
        try
        {
            SmartphoneViewModel result = _smartphoneService.GetSmartphoneById(smartphoneId);
            return Ok(result);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Get all smartphones
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("all")]
    public ActionResult<List<SmartphoneViewModel>> GetAllProcessors()
    {
        try
        {
            var result = _smartphoneService.GetSmartphoneAllSmartphones();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    /// <summary>
    /// Create a smartphone
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult> CreateProcessor(SmartphoneCreationRequest request)
    {
        try
        {
            await _smartphoneService.CreateSmartphone(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Update a smartphone
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("update")]
    public async Task<ActionResult> UpdateProcessor(SmartphoneUpdateRequest request)
    {
        try
        {
            await _smartphoneService.UpdateSmartphone(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Delete a smartphone by Id
    /// </summary>
    /// <param name="smartphoneId"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{smartphoneId}")]
    public async Task<ActionResult> DeleteProcessor(int smartphoneId)
    {
        try
        {
            await _smartphoneService.DeleteSmartphone(smartphoneId);
            return Ok();

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
