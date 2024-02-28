namespace E_CarShop.DataBase.Entities
{
    public class BrandEntity : BaseEntity
    {
        public string Name { get; set; }
        public List<CarEntity> Cars { get; set; }
    }
}