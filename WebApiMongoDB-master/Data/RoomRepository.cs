using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

using HotelReservation.Interfaces;
using HotelReservation.Model;
using MongoDB.Bson;

namespace HotelReservation.Data
{
    public class RoomRepository : IRoomRepository
    {
        private readonly RoomContext _context = null;

        public RoomRepository(IOptions<Settings> settings)
        {
            _context = new RoomContext(settings);
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            try
            {
                return await _context.Rooms.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<Room> GetRoom(string id)
        {
            var filter = Builders<Room>.Filter.Eq("Id", id);

            try
            {
                return await _context.Rooms
                                .Find(filter)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task AddRoom(Room item)
        {
            try
            {
                await _context.Rooms.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveRoom(string id)
        {
            try
            {
                DeleteResult actionResult = await _context.Rooms.DeleteOneAsync(
                     Builders<Room>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged 
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateRoom(string id, string category)
        {
            var filter = Builders<Room>.Filter.Eq(s => s.Id, id);
            var update = Builders<Room>.Update
                                       .Set(s => s.Category, category);
                            
            try
            {
                UpdateResult actionResult = await _context.Rooms.UpdateOneAsync(filter, update);

                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateRoom(string id, Room item)
        {
            try
            {
                ReplaceOneResult actionResult = await _context.Rooms
                                                .ReplaceOneAsync(n => n.Id.Equals(id)
                                                                , item
                                                                , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // Demo function - full document update
        public async Task<bool> UpdateNoteDocument(string id, string category)
        {
            var item = await GetRoom(id) ?? new Room();
            item.Category = category;

            return await UpdateRoom(id, item);
        }

        public async Task<bool> RemoveAllRooms()
        {
            try
            {
                DeleteResult actionResult = await _context.Rooms.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // it creates a compound index (first using UserId, and then Body)
        // MongoDb automatically detects if the index already exists - in this case it just returns the index details
        public async Task<string> CreateIndex()
        {
            try
            {
                return await _context.Rooms.Indexes
                                           .CreateOneAsync(Builders<Room>
                                                                .IndexKeys
                                                           .Ascending(item => item.Cost)
                                                           .Ascending(item => item.Category));
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public Task<bool> UpdateRoomDocument(string id, string body)
        {
            throw new NotImplementedException();
        }
    }
}
