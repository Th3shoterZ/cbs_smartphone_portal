namespace SmartphonePortal_Vervoort_Wagner.Server.Models;

public class Processor
{
    public int ProcessorId { get; set; }
    public string Gigaherz { get; set; } = string.Empty;
    public int CoreCount { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<Smartphone> Smartphones { get; set; } = new();
}