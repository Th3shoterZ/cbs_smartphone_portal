using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartphonePortal_Vervoort_Wagner.Server.Data;
using SmartphonePortal_Vervoort_Wagner.Server.Mappers;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ProcessorController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper<Processor, ProcessorViewModel> _mapper;
    
    public ProcessorController(
        ApplicationDbContext dbContext,
        IMapper<Processor, ProcessorViewModel> mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Get a processor by Id
    /// </summary>
    /// <param name="processorId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{processorId}")]
    public ActionResult<Processor> GetProcessor(int processorId)
    {
        try
        {
            Processor processor = _dbContext.Processors.Where(x => x.ProcessorId == processorId).Single();
            return Ok(processor);

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
    public ActionResult<List<Processor>> GetAllProcessors()
    {
        try
        {
            return Ok(_dbContext.Processors);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    /// <summary>
    /// Create a processor
    /// </summary>
    /// <param name="processorViewModel"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("create")]
    public ActionResult CreateProcessor([FromBody]ProcessorViewModel processorViewModel)
    {
        try
        {
            _dbContext.Processors.Add(_mapper.MapToModel(processorViewModel));
            _dbContext.SaveChanges();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
