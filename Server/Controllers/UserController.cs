using Microsoft.AspNetCore.Mvc;
using SmartphonePortal_Vervoort_Wagner.Server.Data;
using SmartphonePortal_Vervoort_Wagner.Server.Models;

namespace SmartphonePortal_Vervoort_Wagner.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfileController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    public ProfileController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    [Route("{profileId}")]
    public ActionResult<ApplicationUser> GetProfile(string profileId)
    {
        ApplicationUser user = _dbContext.Users.Where(x  => x.Id.Equals(profileId)).Single<ApplicationUser>();
        return Ok(user);
    }
}
