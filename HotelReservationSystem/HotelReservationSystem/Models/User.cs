using System;
using MongoDB.Bson.Serialization.Attributes;


namespace HotelReservationSystem.Models
{
    public class User
    {
        [BsonId]
        public string Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; } = DateTime.Now;
        public Room room { get; set; } = null;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
