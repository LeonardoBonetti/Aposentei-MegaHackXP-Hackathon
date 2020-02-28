using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Hackaton.Application.DTO;
using Hackaton.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrailsController : ControllerBase
    {
        private readonly ITrailService _trailService;
        private readonly IVideoTrailService _videoTrailService;
        private readonly ITextTrailService _textTrailService;
        private readonly IQuizTrailService _quizTrailService;

        public TrailsController(
            ITrailService trailService,
            IVideoTrailService videoTrailService,
            ITextTrailService textTrailService,
            IQuizTrailService quizTrailService

            )
        {
            _trailService = trailService;
            _videoTrailService = videoTrailService;
            _textTrailService = textTrailService;
            _quizTrailService = quizTrailService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _trailService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("/trails/{ID}")]
        public async Task<ActionResult> GetByID(int ID)
        {
            try
            {
                return Ok(await _trailService.GetByID(ID));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("AddVideo")]
        public async Task<ActionResult> AddVideo(VideoTrailAddRequestDto request)
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

        [HttpPost("AddText")]
        public async Task<ActionResult> AddText(TextTrailAddRequestDto request)
        {
            try
            {
                return Ok(await _textTrailService.Add(request));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("AddQuiz")]
        public async Task<ActionResult> AddQuiz(QuizTrailAddRequestDto request)
        {
            try
            {
                return Ok(await _quizTrailService.Add(request));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
