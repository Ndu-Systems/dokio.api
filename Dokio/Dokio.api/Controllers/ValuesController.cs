using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dokio.Contracts.ILoggerService;
using Dokio.Contracts.IRepositoryWrapper;
using Dokio.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dokio.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repoWrapper;
        public ValuesController(ILoggerManager logger, IRepositoryWrapper repoWrapper)
        {
            _logger = logger;
            _repoWrapper = repoWrapper;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Patient> Get()
        {

            var patients = _repoWrapper.Patient.GetAllPatients();

          
            _logger.LogInfo("Patients recieved");
            
           
            //return new string[] { "value1", "value2" };
            return patients;
       
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
