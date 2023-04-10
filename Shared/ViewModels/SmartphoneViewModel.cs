namespace SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

public class SmartphoneViewModel
{
    public int SmartphoneId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public CategoryViewModel Category { get; set; } = new();
    public ManufacturerViewModel Manufacturer { get; set; } = new();
    public double DisplaySize { get; set; }
    public string Resolution { get; set; } = string.Empty;
    public double Weight { get; set; }
    public int Rating { get; set; }
    public List<PictureViewModel> Pictures { get; set; } = new();
    public ProcessorViewModel Processor { get; set; } = new();
}
