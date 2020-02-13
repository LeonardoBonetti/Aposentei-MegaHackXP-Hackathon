using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hackaton.Domain.Entities;
using Hackaton.Domain.Interfaces;
using Hackaton.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Hackaton.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        protected readonly MyContext _context;
        private DbSet<UserEntity> _dataset;

        public UserRepository(MyContext context) : base(context)
        {
            _context = context;
            _dataset = _context.Set<UserEntity>();
        }

        public async Task<bool> LoginAsync(UserEntity user)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Email.Equals(user.Email) && p.Password.Equals(user.Password));
                return result != null ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}