using Microsoft.AspNetCore.Identity;
using SmartphonePortal_Vervoort_Wagner.Server.Data;
using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.Requests;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Services;

public class ProfileService : IProfileService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserStore<ApplicationUser> _userStore;
    private readonly IUserEmailStore<ApplicationUser> _emailStore;
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper<ApplicationUser, ProfileViewModel> _mapper;

    public ProfileService(
        UserManager<ApplicationUser> userManager,
        IUserStore<ApplicationUser> userStore,
        ApplicationDbContext dbContext,
        IMapper<ApplicationUser, ProfileViewModel> mapper)
    {
        _userManager = userManager;
        _userStore = userStore;
        _emailStore = (IUserEmailStore<ApplicationUser>)userStore;
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ProfileViewModel> GetProfileById(string id)
    {
        var user = _dbContext.Users.FirstOrDefault(x => x.Id.Equals(id));
        if (id == null || user == null)
        {
            return new ProfileViewModel();
        }

        var result = _mapper.GetMappedResult(user);
        var roles = await _userManager.GetRolesAsync(user);
        result.Role = roles.FirstOrDefault() ?? string.Empty;
        return result;
    }
    public async Task<ProfileViewModel> GetProfileByEmail(string email)
    {
        var user = _dbContext.Users.FirstOrDefault(x => x.Email.Equals(email));
        if (string.IsNullOrEmpty(email) || user == null)
        {
            return new ProfileViewModel();
        }

        var result = _mapper.GetMappedResult(user);
        var roles = await _userManager.GetRolesAsync(user);
        result.Role = roles.FirstOrDefault() ?? string.Empty;
        return result;
    }

    public async Task<List<ProfileViewModel>> GetAllProfiles()
    {
        List<ProfileViewModel> profiles = new();
        foreach (ApplicationUser user in _dbContext.Users.ToList())
        {
            var temp = _mapper.GetMappedResult(user);
            var roles = await _userManager.GetRolesAsync(user);
            temp.Role = roles.FirstOrDefault() ?? string.Empty;
            profiles.Add(temp);

        }
        return profiles;
    }

    public async Task CreateProfile(ProfileCreationRequest request)
    {
        var user = Activator.CreateInstance<ApplicationUser>();

        await _userStore.SetUserNameAsync(user, request.UserName, CancellationToken.None);
        await _emailStore.SetEmailAsync(user, request.Email, CancellationToken.None);
        await _userManager.CreateAsync(user, request.Password);

        // assign the role
        await _userManager.AddToRoleAsync(user, request.Role);
    }

    public async Task UpdateProfile(ProfileUpdateRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.ProfileId))
        {
            return;
        }
        var user = _dbContext.Users.FirstOrDefault(x => x.Id.Equals(request.ProfileId));

        if (user == null) return;

        if (!string.IsNullOrEmpty(request.Email))
        {
            user.UserName = request.UserName;
            user.Email = request.Email;
        }

        if (!string.IsNullOrEmpty(request.Role) && _dbContext.Roles.Any(x => x.Name.Equals(request.Role)))
        {
            // remove from all other roles before assiging the new one
            var rolesToRemove = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, rolesToRemove);

            // assign the new role
            await _userManager.AddToRoleAsync(user, request.Role);
        }

        // save changes
        await _dbContext.SaveChangesAsync();
        return;
    }

    public async Task DeleteProfile(string id)
    {
        var user = _dbContext.Users.FirstOrDefault(x => x.Id.Equals(id));
        if (user == null || string.IsNullOrEmpty(user.Id)) return;
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
    }
}
