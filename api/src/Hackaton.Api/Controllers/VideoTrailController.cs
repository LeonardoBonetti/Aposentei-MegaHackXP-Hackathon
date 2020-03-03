using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Hackaton.Application.DTO;
using Hackaton.Application.Exceptions;
using Hackaton.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoTrailController : ControllerBase
    {
        private readonly IVideoTrailService _videoTrailService;

        public VideoTrailController(
            IVideoTrailService videoTrailService
        )
        {
            _videoTrailService = videoTrailService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                return Ok(await _videoTrailService.Get(id));
            }
            catch (NotFoundException e)
            {
                return StatusCode((int)HttpStatusCode.NotFound, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(VideoTrailAddRequestDto request)
        {
            try
            {
                return Ok(await _videoTrailService.Add(request));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
