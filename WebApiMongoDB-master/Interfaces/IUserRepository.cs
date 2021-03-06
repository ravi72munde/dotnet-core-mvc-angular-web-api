﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservation.Model;

namespace HotelReservation.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(string id);

        //get user by username
        Task<User> GetUserByUserName(string usename);

        // add new user document
        Task AddUser(User item);

        // remove a single document / user
        Task<bool> RemoveUser(string id);

        // update just a single document / user
        Task<bool> UpdateUser(string id, string username, string password);

        // demo interface - full document update
        Task<bool> UpdateUserDocument(string id, string username, string password);

        // should be used with high cautious, only in relation with demo setup
        Task<bool> RemoveAllUsers();

        // creates a sample index
        Task<string> CreateIndex();
    }
}
