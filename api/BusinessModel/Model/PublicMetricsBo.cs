using API.Interfaces.Model;

namespace API.BusinessModel.Model
{
    public class PublicMetricsBo : IPublicMetricsBo
    {
        public int RetweetCount { get; set; }
        public int ReplyCount { get; set; }
        public int LikeCount { get; set; }
        public int QuoteCount { get; set; }
    }
}
