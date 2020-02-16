using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hackaton.Domain.Entities;
using Hackaton.Domain.Interfaces;
using Hackaton.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Hackaton.Infra.Data.Repository
{
    public class TrailRepository : BaseRepository<TrailEntity>, ITrailRepository
    {
        protected readonly MyContext _context;
        private DbSet<TrailEntity> _dataset;

        public TrailRepository(MyContext context) : base(context)
        {
            _context = context;
            _dataset = _context.Set<TrailEntity>();
        }
    }
}