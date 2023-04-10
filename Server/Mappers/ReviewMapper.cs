using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Mappers;

public class ReviewMapper : IMapper<Review, ReviewViewModel>
{
    public ReviewViewModel GetMappedResult(Review model)
    {
        ReviewViewModel result = new()
        {
            ReviewId = model.ReviewId,
            Text = model.Text,
            Title = model.Title,
            UserId = model.UserId,
            SmartphoneId = model.SmartphoneId,
            Comments = new()
        };

        if (model.Ratings != null)
        {
            List<int> stars = ((List<int>)(from Stars in model.Ratings
                               select Stars));
            result.Rating = (int)stars.Average();
        }

        return result;
    }
}
