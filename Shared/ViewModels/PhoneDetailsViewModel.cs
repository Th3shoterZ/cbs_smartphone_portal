using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

public class PhoneDetailsViewModel
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public string? ManufacturorInfo { get; set; }
    public double DisplaySize { get; set; }
    public string? Resolution { get; set; }
    public double Weight { get; set; }
    public int SmartphoneId { get; set; }
    public List<PictureViewModel>? Pictures { get; set; }
    public List<ProcessorViewModel>? Processors { get; set; }
}
