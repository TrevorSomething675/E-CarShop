using E_CarShop.Core.JsonConverterConfiguration;
using System.Text.Json.Serialization;

namespace E_CarShop.Core.ReponseModels
{
    public class CarResponse : BaseResponse
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public bool IsVisible { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public List<ImageResponse> Images { get; set; }
        public List<UserResponse> Users { get; set; }
        public int BrandId { get; set; }
        public BrandResponse Brand { get; set; }
    }
}