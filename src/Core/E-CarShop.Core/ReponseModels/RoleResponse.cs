namespace E_CarShop.Core.ReponseModels
{
    public class RoleResponse : BaseResponse
    {
        public string Name { get; set; }
        public List<UserResponse> Users { get; set; }
    }
}