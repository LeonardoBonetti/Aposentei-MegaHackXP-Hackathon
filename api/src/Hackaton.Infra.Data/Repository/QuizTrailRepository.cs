using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hackaton.Domain.Entities;
using Hackaton.Domain.Interfaces;
using Hackaton.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Hackaton.Infra.Data.Repository
{
    public class QuizTrailRepository : BaseRepository<QuizTrail>, IQuizTrailRepository
    {
        protected readonly MyContext _context;
        private DbSet<QuizTrail> _dataset;

        public QuizTrailRepository(MyContext context) : base(context)
        {
            _context = context;
            _dataset = _context.Set<QuizTrail>();
        }
    }
}