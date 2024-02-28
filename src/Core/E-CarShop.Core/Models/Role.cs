namespace E_CarShop.Core.Models
{
    public class Role : BaseModel
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}