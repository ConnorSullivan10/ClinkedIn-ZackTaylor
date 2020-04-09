using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.DataAccess;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinkerController : ControllerBase
    {
        private ClinkerRepository _repository = new ClinkerRepository();

        [HttpPost]
        public IActionResult AddClinker(Clinker clinkerToAdd)
        {
            var existingClinker = _repository.GetById(clinkerToAdd.Id);
            if (existingClinker == null)
            {
                _repository.Add(clinkerToAdd);
                return Created("", clinkerToAdd);
            }
            else
            {
                //var updatedClinker = _repository.Update(clinkerToAdd);
                //return Ok(clinkerToAdd);
                return NotFound("Yo this didn't work");
            }
        }
        [HttpGet]
        public IActionResult GetAllClinkers()
        {
            var allClinkers = _repository.GetAll();

            return Ok(allClinkers);
        }
    }
}