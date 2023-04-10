namespace SmartphonePortal_Vervoort_Wagner.Server.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Smartphone> Smartphones { get; set; } = new();
}
