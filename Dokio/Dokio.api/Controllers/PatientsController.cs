using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dokio.Contracts.ILoggerService;
using Dokio.Contracts.IRepositoryWrapper;
using Dokio.Entities.Extensions;
using Dokio.Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dokio.api.Controllers
{
    [Route("api/patients")]
    public class PatientsController : Controller
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repoWrapper;

        public PatientsController(ILoggerManager logger, IRepositoryWrapper repoWrapper)
        {
            _logger = logger;
            _repoWrapper = repoWrapper;
        }

        // GET api/patients
        [HttpGet]
        public IActionResult GetAllPatients ()
        {
            try
            {
                var patients = _repoWrapper.Patient.GetAllPatients();
                _logger.LogInfo($"Returned all patients from database at: {DateTime.Now}");
                return Ok(patients);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllPatients error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }         

        }

        // GET api/patients/1

        [HttpGet("{id}", Name ="PatientById")]
        public IActionResult GetPatientById(Guid id)
        {
            try
            {
                var patient = _repoWrapper.Patient.GetPatientById(id);
                if (patient.IsEmptyObject())
                {
                    _logger.LogError($"Patient with id: {id}, has not been found in our records");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned Patient with id : {id}");
                    return Ok(patient);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPatientById error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreatePatient([FromBody]Patient patient)
        {
            try
            {
                if (patient.IsObjectNull())
                {
                    _logger.LogError("Patient object sent from CreatePatient is Null");
                    return BadRequest("Object null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Patient Object sent from CreatePatient");
                    return BadRequest("Object invalid");
                }
                _repoWrapper.Patient.CreatePatient(patient);
                return CreatedAtRoute("PatientById", new { id = patient.Id }, patient);
                
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreatePatient error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePatient(Guid id, [FromBody]Patient patient)
        {
            try
            {
                if (patient.IsObjectNull())
                {
                    _logger.LogError("Patient object sent from UpdatePatient is Null");
                    return BadRequest("Object null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Patient Object sent from UpdatePatient");
                    return BadRequest("Object invalid");
                }

                var dbPatient = _repoWrapper.Patient.GetPatientById(id);

                _repoWrapper.Patient.UpdateClient(dbPatient,patient);
                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreatePatient error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
