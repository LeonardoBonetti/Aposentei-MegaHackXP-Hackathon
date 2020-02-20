using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hackaton.Domain.Entities;

namespace Hackaton.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> LoginAsync(User user);
        Task<bool> UserExists(string email);
    }
}