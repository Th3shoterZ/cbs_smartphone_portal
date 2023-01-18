using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

public class ProcessorViewModel
{
    public int ProcessorId { get; set; }
    public string? Gigaherz { get; set; }
    public int CoreCount { get; set; }
    public string? Title { get; set; }
    public List<int> PhoneDetailIds { get; set; } = new();
}
