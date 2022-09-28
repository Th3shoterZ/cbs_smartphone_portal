using SmartphonePortal_WV_KW.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphonePortal_WV_KW.core.Services
{
    public interface ISmartphoneDetailsService
    {
        SmartphoneDetailsViewModel GetSmartphoneDetails(int id);
    }
}
