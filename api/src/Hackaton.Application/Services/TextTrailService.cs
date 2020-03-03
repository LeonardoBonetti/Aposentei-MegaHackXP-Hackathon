using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hackaton.Application.DTO;
using Hackaton.Domain.Interfaces;
using Hackaton.Application.Interfaces.Services;
using System.Linq;
using System;
using Hackaton.Domain.Entities;
using Hackaton.Domain.Enums;
using Hackaton.Application.Exceptions;

namespace Hackaton.Infra.Data.Repository
{
    public class TextTrailService : ITextTrailService
    {
        private ITextTrailRepository _repository;
        private IMapper _mapper;

        public TextTrailService(
            ITextTrailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        public async Task<int> Add(TextTrailAddRequestDto request)
        {
            TextTrail textTrail = _mapper.Map<TextTrail>(request);
            textTrail.Trail.TypeID = (int)TrailTypeEnum.Text;

            try
            {
                textTrail = await _repository.InsertAsync(textTrail);
                return textTrail.Trail.Id;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao inserir os dados");
            }
        }

        public async Task<TextTrailGetResponseDto> Get(int id)
        {
            TextTrail trail = await _repository.SelectTrailByID(id);
            TextTrailGetResponseDto trailDto = _mapper.Map<TextTrailGetResponseDto>(trail);

            if (trail == null)
            {
                throw new NotFoundException();
            }

            return trailDto;
        }
    }
}