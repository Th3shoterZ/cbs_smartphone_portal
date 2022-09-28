using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphonePortal_WV_KW.Shared.Models
{
    public class ProcessorModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int CoreCount { get; set; }
        public double GigaHertz { get; set; }
    }
}
