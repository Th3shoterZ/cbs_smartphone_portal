namespace SmartphonePortal_Vervoort_Wagner.Server.Models;

public class Manufacturer
{
    public int ManufacturerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string LinkToHomePage { get; set; } = string.Empty;
    public List<Smartphone> Smartphones { get; set; } = new();
}
