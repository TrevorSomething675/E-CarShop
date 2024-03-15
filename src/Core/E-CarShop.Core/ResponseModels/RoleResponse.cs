namespace E_CarShop.Core.ResponseModels
{
    public class RoleResponse : BaseResponse
    {
        public string Name { get; set; }
        public List<UserResponse> Users { get; set; }
    }
}