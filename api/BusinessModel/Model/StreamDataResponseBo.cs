using API.Interfaces.Model;

namespace API.BusinessModel.Model
{
    public class StreamDataResponseBo : DataResponseBo, IStreamDataResponseBo
    {
        public IPublicMetricsBo PublicMetrics { get; set; }
    }
}
