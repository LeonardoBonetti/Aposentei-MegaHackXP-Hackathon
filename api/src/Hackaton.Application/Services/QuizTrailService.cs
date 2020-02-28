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

namespace Hackaton.Infra.Data.Repository
{
    public class QuizTrailService : IQuizTrailService
    {
        private IQuizTrailRepository _repository;
        private IMapper _mapper;

        public QuizTrailService(
            IQuizTrailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Add(QuizTrailAddRequestDto request)
        {
            QuizTrail trail = _mapper.Map<QuizTrail>(request);
            trail.Trail.TypeID = (int)TrailTypeEnum.Text;

            try
            {
                trail = await _repository.InsertAsync(trail);
                return trail.Trail.Id;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao inserir os dados");
            }
        }
    }
}