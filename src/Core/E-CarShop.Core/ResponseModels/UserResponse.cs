namespace E_CarShop.Core.ResponseModels
{
    public class UserResponse : BaseResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int RoleId { get; set; }
        public RoleResponse Role { get; set; }

        public List<CarResponse> Cars { get; set; }
        public List<NotificationResponse> Notifications { get; set; }
    }
}