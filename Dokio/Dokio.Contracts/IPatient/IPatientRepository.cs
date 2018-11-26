using Dokio.Contracts.IRepositoryBase;
using Dokio.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dokio.Contracts.IPatient
{
    public interface IPatientRepository : IRepositoryBase<Patient>
    {
        IEnumerable<Patient> GetAllPatients();

        Patient GetPatientById(int id);

        bool CreatePatient(Patient model);

        bool UpdateClient(Patient dbPatient, Patient patient);
    }
}
