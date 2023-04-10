using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Mappers;

public class ProcessorMapper : IMapper<Processor, ProcessorViewModel>
{
    public ProcessorViewModel GetMappedResult(Processor model)
    {
        return new ProcessorViewModel
        {
            CoreCount = model.CoreCount,
            Gigaherz = model.Gigaherz,
            ProcessorId = model.ProcessorId,
            Title = model.Title
        };
    }
}
