using SmartphonePortal_Vervoort_Wagner.Shared.Requests;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Interfaces;

public interface IProcessorService
{
    ProcessorViewModel GetProcessorById(int id);
    List<ProcessorViewModel> GetAllProcessors();
    Task CreateProcessor(ProcessorCreationRequest request);
    Task UpdateProcessor(ProcessorUpdateRequest request);
    Task DeleteProcessor(int id);
}
