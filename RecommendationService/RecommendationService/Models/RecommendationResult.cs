using System.Collections.Generic;

namespace RecommendationService.Models
{
    public class RecommendationResult
    {
        public int OriginalScore { get; set; }
        public List<string> Recommendations { get; set; } = new List<string>();
        public List<Recommendation> PlaceRecommendations { get; set; } = new List<Recommendation>();
    }
}