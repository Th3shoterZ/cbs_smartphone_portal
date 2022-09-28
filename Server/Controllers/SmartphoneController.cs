using Microsoft.AspNetCore.Mvc;
using SmartphonePortal_WV.Shared.ViewModels;
using SmartphonePortal_WV.core.Services;

namespace SmartphonePortal_WV.Server.Controllers
{
    [ApiController]
    public class SmartphoneController : ControllerBase
    {
        private readonly ISmartphoneService _smartphoneService;
        private readonly ILogger _logger;

        public SmartphoneController(ISmartphoneService smartphoneService, ILogger logger)
        {
            _smartphoneService = smartphoneService;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/getsmartphones")]
        public List<SmartphoneViewModel> GetSmartphones()
        {
            try
            {
                return _smartphoneService.GetSmartphones();
            }
            catch(Exception e)
            {
                _logger.Log(LogLevel.Error,e.Message);
                throw;
            }
        }

    }
}
