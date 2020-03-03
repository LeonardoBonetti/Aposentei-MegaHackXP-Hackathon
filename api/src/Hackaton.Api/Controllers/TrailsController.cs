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

        public TrailsController(
            ITrailService trailService
            )
        {
            _trailService = trailService;
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
    }
}
