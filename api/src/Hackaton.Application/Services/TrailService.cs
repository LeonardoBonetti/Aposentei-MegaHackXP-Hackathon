using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hackaton.Application.DTO;
using Hackaton.Domain.Interfaces;
using Hackaton.Application.Interfaces.Services;
using System.Linq;
using System;

namespace Hackaton.Infra.Data.Repository
{
    public class TrailService : ITrailService
    {
        private ITrailRepository _repository;
        private ITrailTypeService _trailTypeService;
        private IMapper _mapper;

        public TrailService(
            ITrailRepository repository, ITrailTypeService trailTypeService, IMapper mapper)
        {
            _repository = repository;
            _trailTypeService = trailTypeService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TrailResponseDto>> GetAll()
        {
            var list = await _repository.SelectAsync();
            var dto = _mapper.ProjectTo<TrailResponseDto>(list.AsQueryable());
            List<TrailResponseDto> response = new List<TrailResponseDto>();
            
            foreach (var item in dto)
            {
                item.TrailTypeDto = await _trailTypeService.GetByID(Convert.ToInt32(item.TypeID));
                response.Add(item);
            }

            return response; 
        }

        public async Task<TrailResponseDto> GetByID(int ID)
        {
            var result = await _repository.SelectAsync(ID);
            var dto = _mapper.Map<TrailResponseDto>(result);
            dto.TrailTypeDto = await _trailTypeService.GetByID(result.TypeID);
            return dto;
        }
    }
}