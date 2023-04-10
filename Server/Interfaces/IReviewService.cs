using SmartphonePortal_Vervoort_Wagner.Shared.Requests;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Interfaces;

public interface IReviewService
{
    ReviewViewModel GetReviewById(int id);
    List<ReviewViewModel> GetAllReviews();
    List<ReviewViewModel> GetReviewsForSmartphone(int smartphoneId);
    List<ReviewViewModel> GetReviewsForUser(string userId);
    Task CreateReview(ReviewCreationRequest request);
    Task UpdateReview(ReviewUpdateRequest request);
    Task DeleteReview(int id);
}
