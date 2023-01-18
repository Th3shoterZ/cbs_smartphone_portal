namespace SmartphonePortal_Vervoort_Wagner.Server.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public int SmartphoneId { get; set; }
        public Smartphone? Smartphone { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Rating>? Ratings { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}