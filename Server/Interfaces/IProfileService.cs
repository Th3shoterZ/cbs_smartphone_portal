using SmartphonePortal_Vervoort_Wagner.Shared.Requests;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Interfaces;

public interface IProfileService
{
    Task<ProfileViewModel> GetProfileById(string id);
    Task<List<ProfileViewModel>> GetAllProfiles();
    Task<ProfileViewModel> GetProfileByEmail(string email);
    Task CreateProfile(ProfileCreationRequest request);
    Task UpdateProfile(ProfileUpdateRequest profile);
    Task DeleteProfile(string id);
}
