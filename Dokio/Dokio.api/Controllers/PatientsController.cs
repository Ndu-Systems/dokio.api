using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dokio.Contracts.ILoggerService;
using Dokio.Contracts.IRepositoryWrapper;
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

        // GET api/values
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
    }
}
