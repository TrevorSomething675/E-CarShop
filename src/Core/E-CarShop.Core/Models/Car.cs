namespace E_CarShop.Core.Models
{
    public class Car : BaseModel
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public bool IsVisible { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public List<Image> Images { get; set; }
        public List<User> Users { get; set; }
        public int ModelId { get; set; }
        public Brand Brand { get; set; }
    }
}