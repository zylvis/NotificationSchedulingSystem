using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationSchedulingSystemAPI.Models;
using NotificationSchedulingSystemAPI.Models.Dtos;
using NotificationSchedulingSystemAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSchedulingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            var objList = _companyRepository.GetCompanies();
            var objDto = new List<CompanyDto>();
            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<CompanyDto>(obj));
            }
            return Ok(objDto);
        }

        [HttpGet("{companyId}", Name = "GetCompany")]
        public IActionResult GetCompany(string companyId)
        {
            var obj = _companyRepository.GetCompany(companyId);

            if (obj == null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<CompanyDto>(obj);
            return Ok(objDto);
        }

        [HttpPost]
        public IActionResult CreateCompany([FromBody] Company company)
        {
            if (company == null)
            {
                return BadRequest(ModelState);
            }
            if (_companyRepository.CompanyExistsByName(company.Name))
            {
                ModelState.AddModelError("", "Company Exists!");
                return StatusCode(404, ModelState);
            }

                      
            if (!_companyRepository.CreateCompany(company))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {company.Name}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetCompany", new { companyId = company.Id }, _mapper.Map<CompanyDto>(company));
        }

        [HttpPatch("{companyId}", Name = "UpdateCompany")]
        public IActionResult UpdateCompany(string companyId, [FromBody] CompanyDto companyDto)
        {
            if (companyDto == null || companyId != companyDto.Id)
            {
                return BadRequest(ModelState);
            }

            var companyObj = _mapper.Map<Company>(companyDto);

            if (!_companyRepository.UpdateCompany(companyObj))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {companyObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{companyId}", Name = "DeleteCompany")]
        public IActionResult DeleteCompany(string companyId)
        {
            if (!_companyRepository.CompanyExistsById(companyId))
            {
                return NotFound();
            }

            var companyObj = _companyRepository.GetCompany(companyId);

            if (!_companyRepository.DeleteCompany(companyObj))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {companyObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
