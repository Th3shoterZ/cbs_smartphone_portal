using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Mappers;

public class ReviewMapper : IMapper<Review, ReviewViewModel>
{
    private readonly IMapper<Comment, CommentViewModel> _mapper;

    public ReviewMapper(IMapper<Comment, CommentViewModel> mapper)
    {
        _mapper = mapper;
    }

    public ReviewViewModel GetMappedResult(Review model)
    {
        ReviewViewModel result = new()
        {
            ReviewId = model.ReviewId,
            Text = model.Text,
            Title = model.Title,
            UserId = model.UserId,
            SmartphoneId = model.SmartphoneId,
            UserName = model.User.UserName,
            Rating = model.Rating,
        };

        if (model.Comments != null && model.Comments.Count > 0)
        {
            List<CommentViewModel> comments = new();
            foreach(var com in model.Comments)
            {
                comments.Add(_mapper.GetMappedResult(com));
            }
        }

        return result;
    }
}
