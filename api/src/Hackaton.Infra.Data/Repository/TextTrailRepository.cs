using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hackaton.Domain.Entities;
using Hackaton.Domain.Interfaces;
using Hackaton.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Hackaton.Infra.Data.Repository
{
    public class TextTrailRepository : BaseRepository<TextTrail>, ITextTrailRepository
    {
        protected readonly MyContext _context;
        private DbSet<TextTrail> _dataset;

        public TextTrailRepository(MyContext context) : base(context)
        {
            _context = context;
            _dataset = _context.Set<TextTrail>();
        }

        public async Task<TextTrail> SelectTrailByID(int id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Trail.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}