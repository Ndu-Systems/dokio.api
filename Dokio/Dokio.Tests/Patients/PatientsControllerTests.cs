using Dokio.api.Controllers;
using Dokio.Contracts.ILoggerService;
using Dokio.Contracts.IPatient;
using Dokio.Contracts.IRepositoryWrapper;
using Dokio.Entities.Context;
using Dokio.Entities.Models;
using Dokio.Repository.Patients;
using Dokio.Tests.Patients.FakeService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Dokio.Tests.Patients
{
    public class PatientsControllerTests
    {
        //Use the tripple AAA principle or AA for Get Calls.
        //A = Arrange , A = Act , A = Arrange
        PatientsController _patientsController;        
        
        IPatientRepository _patient;
         

        [Fact]
        public void GetAllPatients_WhenCalled_ReturnOKResults()
        {
            //Arrange 
            IQueryable<Patient> patients = ListOfPatients();
            var mockSet = new Mock<DbSet<Patient>>();
            mockSet.As<IQueryable<Patient>>().Setup(p => p.Provider).Returns(patients.Provider);
            mockSet.As<IQueryable<Patient>>().Setup(p => p.Expression).Returns(patients.Expression);
            mockSet.As<IQueryable<Patient>>().Setup(p => p.ElementType).Returns(patients.ElementType);            
            
            var mockContext = new Mock<RepositoryContext>();
            mockSet.As<IQueryable<Patient>>().Setup(p => p.GetEnumerator()).Returns(patients.GetEnumerator());
            mockContext.Setup(p => p.Patients).Returns(mockSet.Object);

            var mockLoggerService = new Mock<ILoggerManager>();
            mockLoggerService.Setup(l => l.LogInfo("This is a test"));
            var mockRepository = new Mock<IPatientRepository>();
            mockRepository.Setup(p => p.GetAllPatients()).Returns(patients);

            var mockWrapper = new Mock<IRepositoryWrapper>();
            mockWrapper.Setup(mw => mw.Patient).Returns(mockRepository.Object);

            //Act 
            var actual = new PatientsController(mockLoggerService.Object, mockWrapper.Object);
            var result = actual.GetAllPatients();

            //Assert
             
        }
       


        public IQueryable<Patient> ListOfPatients()
        {
           var _patients = new List<Patient>()
            {
                new Patient() {Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), FirstName="FakeJon", Surname = "FakeDoe", Email = "FakeJon@mail.com", StatusId = 1},
                new Patient() {Id = new Guid("2584bafa-1cce-4e81-9009-1611bab71bfc"), FirstName="FakeKing", Surname = "FakeJames", Email = "FakeKing@mail.com", StatusId = 1},
                new Patient() {Id = new Guid("3a097051-b6b0-474f-aeda-ac8fe800b3eb"), FirstName="FakeBen", Surname = "FakeRich", Email = "FakeBen@mail.com", StatusId = 2},
                new Patient() {Id = new Guid("ee7b83be-5257-4716-8290-b082fdab663b"), FirstName="FakeGin", Surname = "FakeKazama", Email = "FakeGin@mail.com", StatusId = 1},

            }.AsQueryable();

            return _patients;
        }
    }
}
