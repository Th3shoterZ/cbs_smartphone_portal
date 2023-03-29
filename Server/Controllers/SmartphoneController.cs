using Microsoft.AspNetCore.Mvc;
using SmartphonePortal_Vervoort_Wagner.Server.Data;

namespace SmartphonePortal_Vervoort_Wagner.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class SmartphoneController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public SmartphoneController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}
