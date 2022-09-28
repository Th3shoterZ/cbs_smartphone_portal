using SmartphonePortal_WV_KW.Shared.Models;

namespace SmartphonePortal_WV_KW.Shared.ViewModels
{
    public class SmartphoneDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ManufacturerInfo { get; set; } = string.Empty;
        public double DisplaySizeInInches { get; set; }
        public string Resolution { get; set; } = string.Empty;
        public double WeightInGrams { get; set; }
        public ProcessorModel? Processor { get; set; }
        public List<ImageModel>? Images { get; set; }
    }
}
