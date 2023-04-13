using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Mappers;

public class ProfileMapper : IMapper<ApplicationUser, ProfileViewModel>
{
    private readonly IMapper<Comment, CommentViewModel> _commentMapper;
    private readonly IMapper<Review, ReviewViewModel> _reviewMapper;
    private readonly IMapper<Rating, RatingViewModel> _ratingMapper;

    public ProfileMapper(
        IMapper<Comment, CommentViewModel> commentMapper,
        IMapper<Review, ReviewViewModel> reviewMapper,
        IMapper<Rating, RatingViewModel> ratingMapper)
    {
        _commentMapper = commentMapper;
        _reviewMapper = reviewMapper;
        _ratingMapper = ratingMapper;
    }

    public ProfileViewModel GetMappedResult(ApplicationUser model)
    {
        ProfileViewModel result = new ProfileViewModel
        {
            Email = model.Email,
            Id = model.Id,
            UserName = model.UserName
        };

        if (model.Comments != null)
        {
            foreach (var comment in model.Comments)
            {
                result.Comments.Add(_commentMapper.GetMappedResult(comment));
            }
        }

        if (model.Ratings != null)
        {
            foreach (Rating rating in model.Ratings)
            {
                result.Ratings.Add(_ratingMapper.GetMappedResult(rating));
            }
        }

        if (model.Reviews != null)
        {
            foreach (Review review in model.Reviews)
            {
                result.Reviews.Add(_reviewMapper.GetMappedResult(review));
            }
        }

        return result;
    }
}
