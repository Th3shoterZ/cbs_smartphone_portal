namespace SmartphonePortal_Vervoort_Wagner.Server.Models;

public class Processor
{
    public int ProcessorId { get; set; }
    public string? Gigaherz { get; set; }
    public int CoreCount { get; set; }
    public string? Title { get; set; }
    public List<PhoneDetails>? PhoneDetails { get; set; }
}