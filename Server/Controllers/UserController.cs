using Microsoft.AspNetCore.Mvc;
using SmartphonePortal_Vervoort_Wagner.Server.Data;
using SmartphonePortal_Vervoort_Wagner.Server.Models;

namespace SmartphonePortal_Vervoort_Wagner.Server.Controllers;

public class UserController : ControllerBase
{
    private Applicato
    public UserController(ApplicationDbContext dbContext)
    {
        
    }

    [HttpGet]
    public async Task<ActionResult> GetProfile(int profileId)
    {
        
        return Ok(new ApplicationUser());
    }
}
