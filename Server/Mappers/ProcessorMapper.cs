using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Mappers
{
    public class ProcessorMapper : IMapper<Processor, ProcessorViewModel>
    {
        public ProcessorMapper()
        {

        }

        public Processor MapToModel(ProcessorViewModel viewModel)
        {
            return new Processor { 
                CoreCount = viewModel.CoreCount,
                Gigaherz = viewModel.Gigaherz,
                Title = viewModel.Title,
                ProcessorId = viewModel.ProcessorId,
            };
        }

        public ProcessorViewModel MapToViewModel(Processor model)
        {
            return new ProcessorViewModel { 
                CoreCount = model.CoreCount,
                Gigaherz = model.Gigaherz,
                ProcessorId = model.ProcessorId,
                Title = model.Title
            };
        }
    }
}
