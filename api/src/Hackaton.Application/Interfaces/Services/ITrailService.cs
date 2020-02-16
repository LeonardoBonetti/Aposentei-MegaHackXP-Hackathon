using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hackaton.Application.DTO;
using Hackaton.Domain.Entities;

namespace Hackaton.Application.Interfaces.Services
{
    public interface ITrailService
    {
        Task<IEnumerable<TrailResponseDto>> GetAll();
        Task<TrailResponseDto> GetByID(int ID);
    }
}