﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timinute.Server.Models;
using Timinute.Server.Repository;
using Timinute.Shared.Dtos;

namespace Timinute.Server.Controllers
{
    [Authorize]
    [ApiController]
    [ValidateAntiForgeryToken]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IRepository<Company> companyRepository;
        private readonly IMapper mapper;

        public CompanyController(IRepository<Company> companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }

        // GET: api/Companies
        [HttpGet(Name = "Companies")]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanies()
        {
            var companyList = await companyRepository.Get();
            return Ok(mapper.Map<IEnumerable<CompanyDto>>(companyList));
        }

        // GET: api/Company
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(string id)
        {
            var company = await companyRepository.GetById(id);
            if (company == null)
            {
                return NotFound("Company not found!");
            }
            return Ok(mapper.Map<CompanyDto>(company));
        }

    }
}