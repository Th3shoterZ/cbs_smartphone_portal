using Duende.IdentityServer.Extensions;
using SmartphonePortal_Vervoort_Wagner.Server.Data;
using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.Requests;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Services;

public class ProcessorService : IProcessorService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper<Processor, ProcessorViewModel> _mapper;

    public ProcessorService(
        ApplicationDbContext dbContext,
        IMapper<Processor, ProcessorViewModel> mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public ProcessorViewModel GetProcessorById(int id)
    {
        var result = _dbContext.Processors.FirstOrDefault(x => x.ProcessorId == id);

        return result != null ? _mapper.GetMappedResult(result) : new();
    }

    public List<ProcessorViewModel> GetAllProcessors()
    {
        List<ProcessorViewModel> result = new List<ProcessorViewModel>();
        foreach (Processor processor in _dbContext.Processors)
        {
            result.Add(_mapper.GetMappedResult(processor));
        }
        return result;
    }
    public async Task CreateProcessor(ProcessorCreationRequest request)
    {
        Processor processor = new Processor
        {
            CoreCount = request.CoreCount,
            Gigaherz = request.Gigaherz,
            Title = request.Title
        };
        _dbContext.Processors.Add(processor);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateProcessor(ProcessorUpdateRequest request)
    {
        var processor = _dbContext.Processors.FirstOrDefault(x => x.ProcessorId == request.ProcessorId);
        if (processor == null) return;

        if (!string.IsNullOrEmpty(request.Gigaherz))
        {
            processor.Gigaherz = request.Gigaherz;
        }
        if (!string.IsNullOrEmpty(request.Title))
        {
            processor.Title = request.Title;
        }
        if (request.CoreCount > 0)
        {
            processor.CoreCount = request.CoreCount;
        }

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteProcessor(int id)
    {
        var processor = _dbContext.Processors.FirstOrDefault(x => x.ProcessorId.Equals(id));
        if (processor == null || processor.ProcessorId == 0) return;
        _dbContext.Processors.Remove(processor);
        await _dbContext.SaveChangesAsync();
    }
}
