namespace SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

public class PictureViewModel
{
    public int PictureId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string PathToData { get; set; } = string.Empty;
    public int SmartphoneId { get; set; }
}