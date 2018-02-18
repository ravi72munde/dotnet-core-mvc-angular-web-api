using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using HotelReservation.Model;

namespace HotelReservation.Data
{
    public class RoomContext
    {
        private readonly IMongoDatabase _database = null;

        public RoomContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Room> Rooms
        {
            get
            {
                return _database.GetCollection<Room>("Room");
            }
        }
    }
}
