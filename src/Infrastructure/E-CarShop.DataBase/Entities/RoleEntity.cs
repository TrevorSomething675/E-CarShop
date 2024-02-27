namespace E_CarShop.DataBase.Entities
{
    public class RoleEntity : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<UserEntity> Users { get; set; }
    }
}