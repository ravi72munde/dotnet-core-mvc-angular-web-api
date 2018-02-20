using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelReservation.Interfaces;
using HotelReservation.Model;
using HotelReservation.Infrastructure;
using System;
using System.Collections.Generic;

namespace HotelReservation.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RoomsController : Controller
    {
        private readonly IRoomRepository _roomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [NoCache]
        [HttpGet]
        public Task<IEnumerable<Room>> Get()
        {
            return GetRoomInternal();
        }

        private async Task<IEnumerable<Room>> GetRoomInternal()
        {
            return await _roomRepository.GetAllRooms();
        }

        // GET api/rooms/5
        [HttpGet("{id}")]
        public Task<Room> Get(string id)
        {
            return GetRoomByIdInternal(id);
        }

        private async Task<Room> GetRoomByIdInternal(string id)
        {
            return await _roomRepository.GetRoom(id) ?? new Room();
        }

        // POST api/rooms
        [HttpPost]
        public void Post([FromBody]string value)
        {
            _roomRepository.AddRoom(new Room() { Category = value });
        }

        // PUT api/rooms/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]string value)
        {
            _roomRepository.UpdateRoomDocument(id, value);
        }

        // DELETE api/rooms/23243423
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _roomRepository.RemoveRoom(id);
        }

        [HttpPost]
        public void Book([FromBody]string value)
        {
            _roomRepository.AddRoom(new Room() { Category = value });
        }
    }
}
