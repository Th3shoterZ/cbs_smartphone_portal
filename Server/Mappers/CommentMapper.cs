using SmartphonePortal_Vervoort_Wagner.Server.Interfaces;
using SmartphonePortal_Vervoort_Wagner.Server.Models;
using SmartphonePortal_Vervoort_Wagner.Shared.ViewModels;

namespace SmartphonePortal_Vervoort_Wagner.Server.Mappers;

public class CommentMapper : IMapper<Comment, CommentViewModel>
{
    public CommentViewModel GetMappedResult(Comment model)
    {
        return new CommentViewModel
        {
            Id = model.CommentId,
            ReviewId = model.Review?.ReviewId ?? 0,
            Text = model.Text,
            UserId = model.UserId
        };
    }
}
