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
            _pateints = new List<Patient>()
            {
                new Patient() {Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), FirstName="FakeJon", Surname = "FakeDoe", Email = "FakeJon@mail.com", StatusId = 1},
                new Patient() {Id = new Guid("2584bafa-1cce-4e81-9009-1611bab71bfc"), FirstName="FakeKing", Surname = "FakeJames", Email = "FakeKing@mail.com", StatusId = 1},
                new Patient() {Id = new Guid("3a097051-b6b0-474f-aeda-ac8fe800b3eb"), FirstName="FakeBen", Surname = "FakeRich", Email = "FakeBen@mail.com", StatusId = 2},
                new Patient() {Id = new Guid("ee7b83be-5257-4716-8290-b082fdab663b"), FirstName="FakeGin", Surname = "FakeKazama", Email = "FakeGin@mail.com", StatusId = 1},

            };
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
