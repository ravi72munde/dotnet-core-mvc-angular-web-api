using System;
using MongoDB.Bson.Serialization.Attributes;


namespace HotelReservationSystem.Models
{
    public class Room
    {
        [BsonId]
        public string Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Image1 { get; set; } = string.Empty;
        public string Image2 { get; set; } = string.Empty;
        public int Floor { get; set; } = 0;
        public string View { get; set; } = string.Empty;
        public int Capacity { get; set; } = 0;
        public int Cost { get; set; } = 0;
        public bool Internet { get; set; } = false;
        public bool Balcony { get; set; } = false;
    }
}
