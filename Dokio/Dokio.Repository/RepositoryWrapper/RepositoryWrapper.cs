using Dokio.Contracts.IPatient;
using Dokio.Contracts.IRepositoryWrapper;
using Dokio.Entities.Context;
using Dokio.Repository.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dokio.Repository.RepositoryWrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        //Declarations
        private RepositoryContext _repoContext { get; set; }

        private IPatientRepository _patient;

        public RepositoryWrapper(RepositoryContext repoContext)
        {
            _repoContext = repoContext;
        }

        //Patient Repository
        public IPatientRepository Patient
        {
            get
            {
                if(_patient == null)
                {
                    _patient = new PatientRepository(_repoContext);
                }
                return _patient;
            }
        }

    }
}
