using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly IChallengeService _chalengeService;
        private readonly IMapper _mapper;
        public ChallengeController(IChallengeService chalengeService, IMapper mapper)
        {
            _chalengeService = chalengeService;
            _mapper = mapper;
        }

        // GET api/challenge
        [HttpGet]
        public ActionResult<List<ChallengeDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if (accelerationId == null && userId == null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<List<ChallengeDTO>>(_chalengeService.FindByAccelerationIdAndUserId(accelerationId.GetValueOrDefault(), userId.GetValueOrDefault())));
        }

        // POST api/challenge
        [HttpPost]
        public ActionResult<ChallengeDTO> Post([FromBody] ChallengeDTO value)
        {
            return Ok(_mapper.Map<ChallengeDTO>(_chalengeService.Save(_mapper.Map<Models.Challenge>(value))));
        }
    }
}
