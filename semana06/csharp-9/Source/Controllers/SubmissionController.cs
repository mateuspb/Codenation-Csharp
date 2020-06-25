using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;
        private readonly IMapper _mapper;
        public SubmissionController(ISubmissionService submissionService, IMapper mapper)
        {
            _submissionService = submissionService;
            _mapper = mapper;
        }

        // GET api/submission/higherScore
        [HttpGet]
        [Route("{higherScore}")]
        public ActionResult<decimal> GetHigherScore(int? challengeId = null)
        {
            if (challengeId == null)
            {
                return NoContent();
            }

            return Ok(_submissionService.FindHigherScoreByChallengeId(challengeId.GetValueOrDefault()));
        }

        // GET api/submission
        [HttpGet]
        public ActionResult<List<SubmissionDTO>> GetAll(int? challengeId = null, int? accelerationId = null)
        {
            if (challengeId == null && accelerationId == null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<List<SubmissionDTO>>(_submissionService.FindByChallengeIdAndAccelerationId(challengeId.GetValueOrDefault(), accelerationId.GetValueOrDefault())));
        }

        // POST api/submission
        [HttpPost]
        public ActionResult<SubmissionDTO> Post([FromBody] SubmissionDTO value)
        {
            return Ok(_mapper.Map<SubmissionDTO>(_submissionService.Save(_mapper.Map<Submission>(value))));
        }

    }
}
