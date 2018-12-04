using Dokio.Contracts.IPatient;
using Dokio.Entities.Context;
using Dokio.Entities.Extensions.Patients;
using Dokio.Entities.Models;
using Dokio.Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dokio.Tests.Patients.FakeService
{
    public class PatientRepositoryFake : RepositoryBase<Patient>, IPatientRepository
    {
        private readonly List<Patient> _pateints;
        
        public PatientRepositoryFake(RepositoryContext context) : base(context)
        {
           
        }
        public bool CreatePatient(Patient model)
        {
            bool isDone = false;
            model.CreateDate = DateTime.Now;
            model.ModifyDate = DateTime.Now;
            model.GlobalKey = Guid.NewGuid().ToString();
            model.Id = Guid.NewGuid();
            try
            {
                _pateints.Add(model);
                isDone = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return isDone;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _pateints;
        }

        public Patient GetPatientById(Guid id)
        {
            return _pateints.Where(p => p.Id == id)
                            .FirstOrDefault();
        }

        public bool UpdateClient(Patient dbPatient, Patient patient)
        {
            bool isDone = false;
            try
            {
                dbPatient.Map(patient);
                _pateints.Where(p => p.Id == dbPatient.Id)
                         .Select(s =>
                         {
                             s.FirstName = dbPatient.FirstName;
                             s.Surname = dbPatient.Surname;
                             s.Email = dbPatient.Email;
                             s.StatusId = dbPatient.StatusId;
                             return s;
                         }).ToList();
                isDone = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return isDone;
        }
    }
}
