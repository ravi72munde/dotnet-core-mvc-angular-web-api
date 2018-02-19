using System;
using Microsoft.AspNetCore.Mvc;

using HotelReservation.Interfaces;
using HotelReservation.Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelReservation.Controllers
{
    [Route("api/[controller]")]
    public class SystemController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoomRepository _roomRepository;

        public SystemController(IUserRepository userRepository, IRoomRepository roomRepository)
        {
            _userRepository = userRepository;
            _roomRepository = roomRepository;
        }

        // Call an initialization -      
        [HttpGet("{setting}")]
        public string Get(string setting)
        {
            if (setting == "init")
            {
                _userRepository.RemoveAllUsers();
                var name = _userRepository.CreateIndex();

                _userRepository.AddUser(new User() { Id = "1", Username = "meven",  Password = "meven", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now});
                _userRepository.AddUser(new User() { Id = "2", Username = "hemant", Password = "hemant", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now});
                _userRepository.AddUser(new User() { Id = "3", Username = "ravi",   Password = "ravi", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now});
                _userRepository.AddUser(new User() { Id = "4", Username = "neha",   Password = "neha", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now}); 


                _roomRepository.RemoveAllRooms();
                var rooms = _roomRepository.CreateIndex();

                _roomRepository.AddRoom(new Room() { Id = "1", Category = "Class A", Type = "A", Floor = 1, Capacity = 2, IsBooked = false });
                _roomRepository.AddRoom(new Room() { Id = "2", Category = "Class A", Type = "A", Floor = 2, Capacity = 2, IsBooked = false });
                _roomRepository.AddRoom(new Room() { Id = "3", Category = "Class B", Type = "B", Floor = 3, Capacity = 4, IsBooked = false });
                _roomRepository.AddRoom(new Room() { Id = "4", Category = "Class B", Type = "B", Floor = 4, Capacity = 4, IsBooked = false });

                return "Database NotesDb was created, and collection 'Notes' and 'Rooms' was filled with 4 sample items";
            }

            return "Unknown";
        }
    }
}
