using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hackaton.Application.DTO;
using Hackaton.Domain.Interfaces;
using Hackaton.Application.Interfaces.Services;
using System.Linq;

namespace Hackaton.Infra.Data.Repository
{
    public class TrailService : ITrailService
    {
        private ITrailRepository _repository;
        private IMapper _mapper;

        public TrailService(ITrailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TrailResponseDto>> GetAll()
        {
            var list = await _repository.SelectAsync();
            return _mapper.ProjectTo<TrailResponseDto>(list.AsQueryable());
        }

        public async Task<TrailResponseDto> GetByID(int ID)
        {
            var result = await _repository.SelectAsync(ID);
            return _mapper.Map<TrailResponseDto>(result);
        }
    }
}