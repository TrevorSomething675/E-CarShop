namespace E_CarShop.Core.Models
{
    public class Notification : BaseModel
    {
        public bool IsRead { get; set; }
        public DateTime SendedDate { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}