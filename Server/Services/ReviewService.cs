using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartphonePortal_Vervoort_Wagner.Server.Data;
using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.Requests;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Services;

public class ReviewService : IReviewService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper<Review, ReviewViewModel> _mapper;
    private readonly UserManager<ApplicationUser> _userManager;

    public ReviewService(
        ApplicationDbContext dbContext,
        IMapper<Review, ReviewViewModel> mapper,
        UserManager<ApplicationUser> userManager)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _userManager = userManager;
    }

    public ReviewViewModel GetReviewById(int id)
    {
        var result = _dbContext.Reviews.FirstOrDefault(x => x.ReviewId == id);

        return result != null ? _mapper.GetMappedResult(result) : new();
    }

    public List<ReviewViewModel> GetReviewsForSmartphone(int smartphoneId)
    {
        var reviews = _dbContext.Reviews
            .Include(x => x.Comments)
            .Include(x => x.User)
            .Where(x => x.SmartphoneId == smartphoneId)
            .ToList();

        List<ReviewViewModel> result = new();
        if (reviews == null) return result;

        foreach (var review in reviews)
        {
            result.Add(_mapper.GetMappedResult(review));
        }
        return result;
    }

    public List<ReviewViewModel> GetReviewsForUser(string userId)
    {
        var reviews = _dbContext.Reviews
            .Include(x => x.Comments)
            .Include(x => x.User)
            .Where(x => x.UserId.Equals(userId))
            .ToList();

        List<ReviewViewModel> result = new();
        if (reviews == null) return result;

        foreach (var review in reviews)
        {
            result.Add(_mapper.GetMappedResult(review));
        }
        return result;
    }

    public List<ReviewViewModel> GetAllReviews()
    {
        List<ReviewViewModel> result = new List<ReviewViewModel>();

        var reviews = _dbContext.Reviews
            .Include(x => x.Comments)
            .Include(x => x.User)
            .ToList();

        foreach (Review review in reviews)
        {
            result.Add(_mapper.GetMappedResult(review));
        }
        return result;
    }

    public async Task CreateReview(ReviewCreationRequest request)
    {
        Smartphone? smartphone = _dbContext.Smartphones.FirstOrDefault(x => x.SmartphoneId == request.SmartphoneId);
        ApplicationUser? user = _dbContext.Users.FirstOrDefault(x => x.Id.Equals(request.UserId));
        if (user == null || smartphone == null) throw new Exception("user and/or smartphone not found");

        Review review = new Review
        {
            Text = request.Text,
            Title = request.Title,
            Smartphone = smartphone,
            User = user,
            Rating = request.Rating,
        };
        _dbContext.Reviews.Add(review);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateReview(ReviewUpdateRequest request)
    {
        var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == request.ReviewId);

        if (category == null) return;

        if (!string.IsNullOrEmpty(request.Text))
        {
            category.Name = request.Text;
        }

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteReview(int id)
    {
        var review = _dbContext.Reviews.FirstOrDefault(x => x.ReviewId == id);
        if (review == null || review.ReviewId == 0) return;
        _dbContext.Reviews.Remove(review);
        await _dbContext.SaveChangesAsync();
    }
}
