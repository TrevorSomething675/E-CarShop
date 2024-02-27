namespace E_CarShop.Core.Models
{
    public class Brand
    {
        public string Name { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}