﻿using Domain.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task ClearUsersAsync();
    }
}
