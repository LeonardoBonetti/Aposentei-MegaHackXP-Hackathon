using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hackaton.Application.DTO;
using Hackaton.Domain.Interfaces;
using Hackaton.Application.Interfaces.Services;
using System.Linq;

namespace Hackaton.Infra.Data.Repository
{
    public class TrailTypeService : ITrailTypeService
    {
        private ITrailTypeRepository _repository;
        private IMapper _mapper;

        public TrailTypeService(ITrailTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TrailTypeDto> GetByID(int ID)
        {
            var result = await _repository.SelectAsync(ID);
            return _mapper.Map<TrailTypeDto>(result);
        }
    }
}