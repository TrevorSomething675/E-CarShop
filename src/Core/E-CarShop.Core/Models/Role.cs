namespace E_CarShop.Core.Models
{
    public class Role : BaseModel
    {
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}