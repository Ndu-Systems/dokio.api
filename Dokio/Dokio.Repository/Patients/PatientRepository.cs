using Dokio.Contracts.IPatient;
using Dokio.Entities.Context;
using Dokio.Entities.Extensions.Patients;
using Dokio.Entities.Models;
using Dokio.Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dokio.Repository.Patients
{
    public class PatientRepository
        : RepositoryBase<Patient>, IPatientRepository
    {
        public PatientRepository(RepositoryContext context)
            : base(context) { }

        public bool CreatePatient(Patient model)
        {
            bool isDone = false;
            model.CreateDate = DateTime.Now;
            model.ModifyDate = DateTime.Now;
            model.GlobalKey =  Guid.NewGuid().ToString();
            model.Id = Guid.NewGuid();
            try
            {
                Create(model);
                Save();
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
            return FindAll().Where(p => p.StatusId == 1);
        }

        public Patient GetPatientById(Guid id)
        {
            return FindByCondition(patient => patient.Id.Equals(id))
                     .DefaultIfEmpty(new Patient())
                     .FirstOrDefault();
        }

        public bool UpdateClient(Patient dbPatient, Patient patient)
        {           
            bool isDone = false;
            try
            {
                dbPatient.Map(patient);
                Update(dbPatient);
                Save();
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
