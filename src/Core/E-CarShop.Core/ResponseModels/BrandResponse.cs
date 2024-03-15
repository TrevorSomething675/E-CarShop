using E_CarShop.Core.Models;

namespace E_CarShop.Core.ResponseModels
{
    public class BrandResponse : BaseResponse
    {
        public string Name { get; set; }
        public List<CarResponse> Cars { get; set; }
    }
}