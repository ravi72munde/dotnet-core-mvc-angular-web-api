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

                _roomRepository.AddRoom(new Room() { Id = "1", Category = "Gramercy Queen", Type = "A", Image1 = "room1.png", Floor = 1, Cost = 200, Capacity = 2, IsBooked = false });
                _roomRepository.AddRoom(new Room() { Id = "2", Category = "Lexington King", Type = "A", Image1 = "room2.png", Floor = 1, Cost = 300, Capacity = 2, IsBooked = false });
                _roomRepository.AddRoom(new Room() { Id = "3", Category = "Gramercy Double Double", Type = "A", Image1 = "room3.png", Floor = 1, Cost = 400, Capacity = 2, IsBooked = false });
                _roomRepository.AddRoom(new Room() { Id = "4", Category = "Lexington Premier King", Type = "A", Image1 = "room4.png", Floor = 2, Cost = 350, Capacity = 5, IsBooked = false });
                _roomRepository.AddRoom(new Room() { Id = "5", Category = "Park View Premier King", Type = "A", Image1 = "room5.png", Floor = 2, Cost = 270, Capacity = 2, IsBooked = false });
                _roomRepository.AddRoom(new Room() { Id = "6", Category = "Gramercy Junior Suit", Type = "A", Image1 = "room6.png", Floor = 2, Cost = 450, Capacity = 3, IsBooked = false });
                _roomRepository.AddRoom(new Room() { Id = "7", Category = "Gramercy Suit", Type = "A", Image1 = "room7.png", Floor = 3, Cost = 560, Capacity = 2, IsBooked = false });
                _roomRepository.AddRoom(new Room() { Id = "8", Category = "Park View Premier Suite", Type = "A", Image1 = "room8.png", Floor = 3, Cost = 370, Capacity = 4, IsBooked = false });
                _roomRepository.AddRoom(new Room() { Id = "9", Category = "Park View Luxury Suite", Type = "A", Image1 = "room9.png", Floor = 3, Cost = 290, Capacity = 2, IsBooked = false });
                _roomRepository.AddRoom(new Room() { Id = "10", Category = "Penthouse Suite", Type = "A", Image1 = "room10.png", Floor = 4, Cost = 1000, Capacity = 7, IsBooked = false });

                return "Database NotesDb was created, and collection 'Notes' and 'Rooms' was filled with 4 sample items";
            }

            return "Unknown";
        }
    }
}
