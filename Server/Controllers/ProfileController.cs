using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SmartphonePortal_Vervoort_Wagner.Server.Data;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.Requests;

namespace SmartphonePortal_Vervoort_Wagner.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfileController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserStore<ApplicationUser> _userStore;
    private readonly IUserEmailStore<ApplicationUser> _emailStore;

    public ProfileController(
    ApplicationDbContext dbContext,
    UserManager<ApplicationUser> userManager,
    IUserStore<ApplicationUser> userStore)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _userStore = userStore;
        _emailStore = (IUserEmailStore<ApplicationUser>)userStore;
    }

    /// <summary>
    /// Get a user profile by Id
    /// </summary>
    /// <param name="profileId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{profileId}")]
    public ActionResult<ApplicationUser> GetProfile(string profileId)
    {
        try
        {
            ApplicationUser? user = _dbContext.Users.FirstOrDefault(x => x.Id == profileId);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Get all user profiles
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("all")]
    public ActionResult<List<ApplicationUser>> GetAllProfiles()
    {
        try
        {
            return Ok(_dbContext.Users);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Create a user profile
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateProfile(UserCreationRequest request)
    {
        try
        {
            var user = Activator.CreateInstance<ApplicationUser>();

            await _userStore.SetUserNameAsync(user, request.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, request.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, request.Password);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
