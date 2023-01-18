namespace SmartphonePortal_Vervoort_Wagner.Server.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int Stars { get; set; }
        public int SmartphoneId { get; set; }
        public Smartphone? Smartphone { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public Review? Review { get; set; }
    }
}