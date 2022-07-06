namespace API.Domain.Model.ApiModel
{
    public class StreamDataResponse
    {
        public string id { get; set; }
        public PublicMetrics public_metrics { get; set; }
        public string text { get; set; }
    }
}
