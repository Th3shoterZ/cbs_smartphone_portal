namespace SmartphonePortal_Vervoort_Wagner.Shared.Responses;

public class FileUploadResponse
{
    public bool Uploaded { get; set; }
    public string? FileName { get; set; }
    public string? StoredFileName { get; set; }
    public int ErrorCode { get; set; }
}
