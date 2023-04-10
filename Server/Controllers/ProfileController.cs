using Microsoft.AspNetCore.Mvc;
using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Shared.Requests;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _profileService;

    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    /// <summary>
    /// Get a user profile by Id
    /// </summary>
    /// <param name="profileId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("id/{profileId}")]
    public async Task<ActionResult<ProfileViewModel>> GetProfileById(string profileId)
    {
        try
        {
            var user = await _profileService.GetProfileById(profileId);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Get a user profile by email
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("email/{email}")]
    public async Task<ActionResult<ProfileViewModel>> GetProfileByEmail(string email)
    {
        try
        {
            var result = await _profileService.GetProfileByEmail(email);
            return Ok(result);
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
    public async Task<ActionResult<List<ProfileViewModel>>> GetAllProfiles()
    {
        try
        {
            List<ProfileViewModel> result = await _profileService.GetAllProfiles();
            return Ok(result);
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
    public async Task<ActionResult> CreateProfile(ProfileCreationRequest request)
    {
        try
        {
            await _profileService.CreateProfile(request);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }

    }

    /// <summary>
    /// Update a user profile
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("update")]
    public async Task<ActionResult> UpdateProfile(ProfileUpdateRequest request)
    {
        try
        {
            await _profileService.UpdateProfile(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Delete a user profile
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("delete/{userId}")]
    public async Task<ActionResult> DeleteProfile(string userId)
    {
        try
        {
            await _profileService.DeleteProfile(userId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
