namespace SmartphonePortal_Vervoort_Wagner.Server.Models;

public class Picture
{
    public int PictureId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string PathToData { get; set; } = string.Empty;
    public int SmartphoneId { get; set; }
    public Smartphone Smartphone { get; set; } = new();
}