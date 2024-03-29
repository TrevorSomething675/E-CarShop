﻿using System.Text.Json.Serialization;

namespace E_CarShop.Core.Models
{
    public class Image : BaseModel
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Base64String { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}