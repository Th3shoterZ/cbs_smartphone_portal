using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartphonePortal_Vervoort_Wagner.Server.Data;
using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Server.Mappers;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.Requests;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProcessorController : ControllerBase
{
    private readonly IProcessorService _processorService;

    public ProcessorController(IProcessorService processorService)
    {
        _processorService = processorService;
    }

    /// <summary>
    /// Get a processor by Id
    /// </summary>
    /// <param name="processorId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{processorId}")]
    public ActionResult<ProcessorViewModel> GetProcessor(int processorId)
    {
        try
        {
            ProcessorViewModel result = _processorService.GetProcessorById(processorId);
            return Ok(result);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Get all processors
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("all")]
    public ActionResult<List<ProcessorViewModel>> GetAllProcessors()
    {
        try
        {
            var result = _processorService.GetAllProcessors();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    /// <summary>
    /// Create a processor
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult> CreateProcessor(ProcessorCreationRequest request)
    {
        try
        {
            await _processorService.CreateProcessor(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Update a processor
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("update")]
    public async Task<ActionResult> UpdateProcessor(ProcessorUpdateRequest request)
    {
        try
        {
            await _processorService.UpdateProcessor(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Delete a processor
    /// </summary>
    /// <param name="processorId"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{processorId}")]
    public async Task<ActionResult> DeleteProcessor(int processorId)
    {
        try
        {
            await _processorService.DeleteProcessor(processorId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
