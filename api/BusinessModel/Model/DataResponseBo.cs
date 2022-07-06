using API.Interfaces.Model;

namespace API.Business.Model
{
    public class DataResponseBo: IDataResponseBo
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }
}
