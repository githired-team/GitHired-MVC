﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models.Interfaces
{
    public interface IUserManager
    {
        Task<IEnumerable<User>> SearchUserName(string name);

        Task CreateUser(User user);

        Task<User> GetUserById(int id);

        Task UpdateUser(User user);

        Task DeleteUser(int id);

        Task<User> GetUserByName(string name);
    }
}
