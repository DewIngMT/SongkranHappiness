namespace RecommendationService.Models
{
    public class Recommendation
    {
        public string Place { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Region { get; set; }
        public string BestTimeToGo { get; set; }
        public decimal EstimatedCost { get; set; }
        public List<string> Activities { get; set; } = new List<string>();
    }
}