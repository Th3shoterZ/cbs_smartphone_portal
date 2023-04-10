using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Mappers;

public class RatingMapper : IMapper<Rating, RatingViewModel>
{
    public RatingViewModel GetMappedResult(Rating model)
    {
        return new()
        {
            RatingId = model.RatingId,
            SmartphoneId = model.SmartphoneId,
            Stars = model.Stars,
            UserId = model.UserId,
            ReviewId = model.Review?.ReviewId ?? 0
        }; ;
    }
}
