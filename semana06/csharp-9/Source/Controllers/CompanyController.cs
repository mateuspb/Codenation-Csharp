﻿using System.Collections.Generic;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        // GET api/company/{id}
        [HttpGet("{id}")]
        public ActionResult<CompanyDTO> Get(int id)
        {
            return Ok(_mapper.Map<CompanyDTO>(_companyService.FindById(id)));
        }

        // GET api/company
        [HttpGet]
        public ActionResult<List<CompanyDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if ((accelerationId == null && userId == null) || (accelerationId != null && userId != null))
            {
                return NoContent();
            }

            if (accelerationId != null)
            {
                return Ok(_mapper.Map<List<CompanyDTO>>(_companyService.FindByAccelerationId(accelerationId.GetValueOrDefault())));
            }
            else
            {
                return Ok(_mapper.Map<List<CompanyDTO>>(_companyService.FindByUserId(userId.GetValueOrDefault())));
            }
        }

        // POST api/company
        [HttpPost]
        public ActionResult<CompanyDTO> Post([FromBody] CompanyDTO value)
        {
            return Ok(_mapper.Map<CompanyDTO>(_companyService.Save(_mapper.Map<Company>(value))));
        }
    }
}
