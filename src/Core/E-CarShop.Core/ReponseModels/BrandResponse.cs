using E_CarShop.Core.Models;

namespace E_CarShop.Core.ReponseModels
{
    public class BrandResponse : BaseResponse
    {
        public string Name { get; set; }
        public List<CarResponse> Cars { get; set; }
    }
}