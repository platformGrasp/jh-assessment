using API.Interfaces.Model;

namespace API.Business.Model
{
    public class StreamDataResponseBo : DataResponseBo, IStreamDataResponseBo
    {
        public IPublicMetricsBo PublicMetrics { get; set; }
    }
}
