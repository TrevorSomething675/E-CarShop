using E_CarShop.Core.Models;

namespace E_CarShop.Core.ReponseModels
{
    public class ImageResponse : BaseResponse
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public int CarId { get; set; }
        public CarResponse Car { get; set; }
    }
}