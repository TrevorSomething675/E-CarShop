namespace E_CarShop.Core.ResponseModels
{
    public class ImageResponse : BaseResponse
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Base64String { get; set; }
        public int CarId { get; set; }
        public CarResponse Car { get; set; }
    }
}