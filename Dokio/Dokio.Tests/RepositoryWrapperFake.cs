using Dokio.Contracts.IPatient;
using Dokio.Contracts.IRepositoryWrapper;
using Dokio.Entities.Context;
using Dokio.Entities.Models;
using Dokio.Tests.Patients.FakeService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dokio.Tests
{
    public class RepositoryWrapperFake : IRepositoryWrapper
    {
        private readonly RepositoryContext _context;
        private IPatientRepository _patient;
 

        public RepositoryWrapperFake(RepositoryContext context)
        {
            _context = context;
        } 
        public IPatientRepository Patient
        {
            get
            {
                if (_patient == null)
                {
                    _patient = new PatientRepositoryFake(_context);
                }
                return _patient;
            }
        }
    }
}
