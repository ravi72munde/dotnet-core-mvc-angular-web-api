﻿using System.Threading.Tasks;
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
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [NoCache]
        [HttpGet]
        public Task<IEnumerable<User>> Get()
        {
            return GetUserInternal();
        }

        private async Task<IEnumerable<User>> GetUserInternal()
        {
            return await _userRepository.GetAllUsers();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public Task<User> Get(string id)
        {
            return GetUserByIdInternal(id);
        }

        private async Task<User> GetUserByIdInternal(string id)
        {
            return await _userRepository.GetUser(id) ?? new User();
        }

        // GET api/users/meven
        [HttpGet("name/{name}")]
        public Task<User> GetUser(string name)
        {
            return GetUserByUsername(name);
        }

        private async Task<User> GetUserByUsername(string username)
        {
            return await _userRepository.GetUserByUserName(username) ?? new User();
        }

        // POST api/user
        [HttpPost]
        public void Post([FromBody]User user)
        {
            _userRepository.AddUser(new User() { Username = user.Username, Password = user.Password, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now });
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]string username, [FromBody]string password)
        {
            _userRepository.UpdateUserDocument(id, username, password);
        }
            
        // DELETE api/user/23243423
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _userRepository.RemoveUser(id);
        }
    }
}   
