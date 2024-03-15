namespace E_CarShop.Core.RequestModels
{
    public class ImageRequest
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Base64String { get; set; }
        public int CarId { get; set; }
        public CarRequest Car { get; set; }
    }
}
