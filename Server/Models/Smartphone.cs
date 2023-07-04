namespace SmartphonePortal_Vervoort_Wagner.Server.Models;

public class Smartphone
{
    public int SmartphoneId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public Category Category { get; set; } = new();
    public string Description { get; set; } = string.Empty;
    public int ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; } = new();
    public double DisplaySize { get; set; }
    public string Resolution { get; set; } = string.Empty;
    public double Weight { get; set; }
    public int ProcessorId { get; set; }
    public Processor Processor { get; set; } = new();
    public List<Picture> Pictures { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
}
