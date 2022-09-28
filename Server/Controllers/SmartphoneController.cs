using Microsoft.AspNetCore.Mvc;
using SmartphonePortal_WV_KW.core.Services;
using SmartphonePortal_WV_KW.Shared.ViewModels;

namespace SmartphonePortal_WV_KW.Server.Controllers
{
    [ApiController]
    public class SmartphoneController : ControllerBase
    {
        private readonly ISmartphoneService _smartphoneService;
        private readonly ISmartphoneDetailsService _smartphoneDetailsService;
        private readonly ILogger _logger;

        public SmartphoneController(ISmartphoneService smartphoneService, ILogger logger, ISmartphoneDetailsService smartphoneDetailsService)
        {
            _smartphoneService = smartphoneService;
            _logger = logger;
            _smartphoneDetailsService = smartphoneDetailsService;
        }

        [HttpGet]
        [Route("api/getsmartphones")]
        public List<SmartphoneViewModel> GetSmartphones()
        {
            try
            {
                return _smartphoneService.GetSmartphones();
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("api/getsmartphonedetails")]
        public SmartphoneDetailsViewModel GetSmartphoneDetails(int id)
        {
            try
            {
                return _smartphoneDetailsService.GetSmartphoneDetails(id);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }

    }
}
