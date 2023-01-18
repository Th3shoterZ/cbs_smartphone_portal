namespace SmartphonePortal_Vervoort_Wagner.Server.Models;

public class PhoneDetails
{
    public int PhoneDetailsId { get; set; }
    public string? Description { get; set; }
    public string? ManufacturorInfo { get; set; }
    public double DisplaySize { get; set; }
    public string? Resolution { get; set; }
    public double Weight { get; set; }
    public int SmartphoneId { get; set; } 
    public List<PhoneDetailsProcessor>? PhoneDetailsProcessors { get; set; }
    public List<Picture>? Pictures { get; set; }
    public Smartphone? Smartphone { get; set; }
}