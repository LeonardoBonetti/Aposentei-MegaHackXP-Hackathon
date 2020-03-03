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
    public class TextTrailController : ControllerBase
    {
        private readonly ITextTrailService _textTrailService;

        public TextTrailController(
            ITextTrailService textTrailService
        )
        {
            _textTrailService = textTrailService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                return Ok(await _textTrailService.Get(id));
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
        public async Task<ActionResult> Post(TextTrailAddRequestDto request)
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
    }
}
