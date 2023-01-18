using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

public class SmartphoneViewModel
{
    public int? SmartphoneId { get; set; }
    public string? Name { get; set; }
    public string? Category { get; set; }
    public int TotalRating { get; set; }
}
