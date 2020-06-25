using System.Collections.Generic;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly IMapper _mapper;

        public CandidateController(ICandidateService candidateService, IMapper mapper)
        {
            _candidateService = candidateService;
            _mapper = mapper;
        }

        // GET api/candidate
        [HttpGet]
        public ActionResult<List<CandidateDTO>> GetAll(int? companyId = null, int? accelerationId = null)
        {
            if ((companyId == null && accelerationId == null) || (companyId != null && accelerationId != null))
            {
                return NoContent();
            }

            if (companyId != null)
            {
                return Ok(_mapper.Map<List<CandidateDTO>>(_candidateService.FindByCompanyId(companyId.GetValueOrDefault())));
            }
            else
            {
                return Ok(_mapper.Map<List<CandidateDTO>>(_candidateService.FindByAccelerationId(accelerationId.GetValueOrDefault())));
            }
        }

        // GET api/candidate/{userId}/{accelerationId}/{companyId}
        [HttpGet("{id}")]
        public ActionResult<CandidateDTO> Get(int userId , int accelerationId, int companyId)
        {
            return Ok(_mapper.Map<CandidateDTO>(_candidateService.FindById(userId, accelerationId, companyId)));
        }

        // POST api/candidate
        [HttpPost]
        public ActionResult<CandidateDTO> Post([FromBody] CandidateDTO value)
        {
            return Ok(_mapper.Map<CandidateDTO>(_candidateService.Save(_mapper.Map<Candidate>(value))));
        }

    }
}
