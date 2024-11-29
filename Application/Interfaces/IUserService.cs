﻿using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUserAsync(string name, string lastName, string email, string password, string rol);
    }
}
