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
    public class VideoTrailService : IVideoTrailService
    {
        private IVideoTrailRepository _repository;
        private IMapper _mapper;

        public VideoTrailService(
            IVideoTrailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Add(VideoTrailAddRequestDto request)
        {
            VideoTrail videoTrail = _mapper.Map<VideoTrail>(request);
            videoTrail.Trail.TypeID = (int)TrailTypeEnum.Video;

            try
            {
                videoTrail = await _repository.InsertAsync(videoTrail);
                return videoTrail.Trail.Id;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao inserir os dados");
            }
        }
    }
}