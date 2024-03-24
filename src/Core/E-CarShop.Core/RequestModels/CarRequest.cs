using E_CarShop.Core.ResponseModels;

namespace E_CarShop.Core.RequestModels
{
    public class CarRequest
    {
        public int Id { get; set; }
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
