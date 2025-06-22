using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobSeekerAPI.Data;
using JobSeekerAPI.Models;
using JobSeekerAPI.Repositories;
using JobSeekerAPI.Services;
using JobSeekerAPI.Dtos;

namespace JobSeekerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _companyService.GetAllCompanyAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyDto companyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var company = new Company
            {
                Name = companyDto.Name,
                Description = companyDto.Description,
                Industry = companyDto.Industry
            };

            var success = await _companyService.CreateCompanyAsync(company);
            return success ? CreatedAtAction(nameof(GetById), new { id = company.Id }, company) : StatusCode(500);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CompanyDto companyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCompany = await _companyService.GetCompanyByIdAsync(id);
            if (existingCompany == null)
            {
                return NotFound();
            }

            existingCompany.Name = companyDto.Name;
            existingCompany.Description = companyDto.Description;
            existingCompany.Industry = companyDto.Industry;

            await _companyService.UpdateCompanyAsync(existingCompany);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comp = await _companyService.GetCompanyByIdAsync(id);
            if (comp == null)
            {
                return NotFound();
            }
            await _companyService.DeleteCompanyAsync(id);
            return NoContent();
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var company = await _companyService.GetCompanyByNameAsync(name);
            return company == null ? NotFound() : Ok(company);
        }
    }
}