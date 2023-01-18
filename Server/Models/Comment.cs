namespace SmartphonePortal_Vervoort_Wagner.Server.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? Text { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public Review? Review { get; set; }
    }
}