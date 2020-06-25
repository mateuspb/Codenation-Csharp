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
    public class AccelerationController : ControllerBase
    {
        private readonly IAccelerationService _accelerationService;
        private readonly IMapper _mapper;

        public AccelerationController(IAccelerationService accelerationService, IMapper mapper)
        {
            _accelerationService = accelerationService;
            _mapper = mapper;
        }

        // GET api/acceleration/{id}
        [HttpGet("{id}")]
        public ActionResult<AccelerationDTO> Get(int id)
        {
            return Ok(_mapper.Map<AccelerationDTO>(_accelerationService.FindById(id)));
        }

        // GET api/acceleration
        [HttpGet]
        public ActionResult<List<AccelerationDTO>> GetAll(int? companyId = null)
        {
            if (companyId == null) 
            {
                return NoContent();
            }

            return Ok(_mapper.Map<List<AccelerationDTO>>(_accelerationService.FindByCompanyId(companyId.GetValueOrDefault())));
            
        }

        // POST api/acceleration
        [HttpPost]
        public ActionResult<AccelerationDTO> Post([FromBody] AccelerationDTO value)
        {
            return Ok(_mapper.Map<AccelerationDTO>(_accelerationService.Save(_mapper.Map<Acceleration>(value))));
        }
    }
}
