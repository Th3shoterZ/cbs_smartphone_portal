using SmartphonePortal_WV.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphonePortal_WV.core.Services
{
    public interface ISmartphoneService
    {
        List<SmartphoneViewModel> GetSmartphones();
    }
}
