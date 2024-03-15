namespace E_CarShop.Core.ResponseModels
{
    public class NotificationResponse : BaseResponse
    {
        public bool IsRead { get; set; }
        public DateTime SendedDate { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public UserResponse User { get; set; }
    }
}