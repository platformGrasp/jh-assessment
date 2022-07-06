using API.BusinessModel.Model;
using API.Domain.Model.ApiModel;
using API.Interfaces.Model;

namespace API.BusinessModel.Extensions
{
    public static class ModelConverter
    {
        public static IStreamDataResponseBo AsStreamDataResponse(this StreamResponse input)
        {
            if (input.data != null)
            {
                var output = new StreamDataResponseBo
                {
                    PublicMetrics = new PublicMetricsBo
                    {
                        LikeCount = input.data.public_metrics.like_count,
                        QuoteCount = input.data.public_metrics.quote_count,
                        ReplyCount = input.data.public_metrics.reply_count,
                        RetweetCount = input.data.public_metrics.retweet_count
                    },
                    Id = input.data.id,
                    Text = input.data.text,
                };
                return output;
            }

            return null;
        }

        public static IDataResponseBo AsDataResponse(this Response input)
        {
            var output = new DataResponseBo
            {
                Id = input.data.id,
                Text = input.data.text,
            };
            return output;
        }
    }
}
