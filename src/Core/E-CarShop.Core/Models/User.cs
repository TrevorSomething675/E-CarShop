﻿namespace E_CarShop.Core.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public List<Car> Cars { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}