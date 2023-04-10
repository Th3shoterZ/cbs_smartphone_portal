﻿using SmartphonePortal_Vervoort_Wagner.Server.Data;
using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.Requests;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Services;

public class ReviewService : IReviewService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper<Review, ReviewViewModel> _mapper;

    public ReviewService(
        ApplicationDbContext dbContext, 
        IMapper<Review, ReviewViewModel> mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public ReviewViewModel GetReviewById(int id)
    {
        var result = _dbContext.Reviews.FirstOrDefault(x => x.ReviewId == id);

        return result != null ? _mapper.GetMappedResult(result) : new();
    }

    public List<ReviewViewModel> GetReviewsForSmartphone(int smartphoneId)
    {
        var reviews = _dbContext.Reviews.Where(x => x.SmartphoneId == smartphoneId);
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
        var reviews = _dbContext.Reviews.Where(x => x.UserId.Equals(userId));
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
        foreach (Review review in _dbContext.Reviews)
        {
            result.Add(_mapper.GetMappedResult(review));
        }
        return result;
    }
    public async Task CreateReview(ReviewCreationRequest request)
    {
        Review review = new Review
        {
            Text = request.Text,
            Title = request.Title,
            
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
        var review = _dbContext.Reviews.FirstOrDefault(x => x.ReviewId ==id);
        if (review == null || review.ReviewId == 0) return;
        _dbContext.Reviews.Remove(review);
        await _dbContext.SaveChangesAsync();
    }
}