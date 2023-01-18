namespace SmartphonePortal_Vervoort_Wagner.Server.Models;

public class Picture
{
    public int PictureId { get; set; }
    public string? Title { get; set; }
    public string? PathToData { get; set; }
    public int PhoneDetailsId { get; set; }
    public PhoneDetails? PhoneDetails { get; set; }
}