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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Dokio.Tests.Patients
{
    public class PatientsControllerTests
    {      
        [Fact]
        public void GetAllPatients_WhenCalled_Return200OKResults() {
            var helper = new PatientHelper();
            //Arrange 
            IQueryable<Patient> patients = helper.ListOfPatients();
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
            var controller = new PatientsController(mockLoggerService.Object, mockWrapper.Object);
            var result = controller.GetAllPatients() as OkObjectResult;

            //Assert
            
            Assert.NotNull(result.StatusCode);
            Assert.Equal(200, result.StatusCode);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetAllPatients_WhenCalled_ReturnAllPatients()
        {
            var helper = new PatientHelper();
            //Arrange 
            IQueryable<Patient> patients = helper.ListOfPatients();
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
            var controller = new PatientsController(mockLoggerService.Object, mockWrapper.Object);
            var result = controller.GetAllPatients() as OkObjectResult;           
            //Assert
            
            Assert.NotNull(result);
            var patientsList = result.Value;
            Assert.NotNull(patientsList);

        }
        [Fact]
        public void GetPatientById_UnknownIDIsPassed_MustReturnNotFound()
        {
            var helper = new PatientHelper();
            //Arrange 
            IQueryable<Patient> patients = helper.ListOfPatients();
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
            var mockWrapper = new Mock<IRepositoryWrapper>();
            mockWrapper.Setup(mw => mw.Patient).Returns(mockRepository.Object);

            //Act 
            var controller = new PatientsController(mockLoggerService.Object, mockWrapper.Object);
            var result = controller.GetPatientById(Guid.NewGuid()) as ObjectResult;

            //Assert
            Assert.Equal(500, result.StatusCode);
        }

        [Fact]
        public void GetPatientById_WhenCalled_MustReturn200OkResult()
        {
            var helper = new PatientHelper();
            //Arrange 
            IQueryable<Patient> patients = helper.ListOfPatients();
            Patient patient = helper.GetPatient();
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
            mockRepository.Setup(mr => mr.GetPatientById(new Guid("03a98ce8-c141-48f6-b490-0ddba4074add"))).Returns(patient);
            var mockWrapper = new Mock<IRepositoryWrapper>();
            mockWrapper.Setup(mw => mw.Patient).Returns(mockRepository.Object);

            //Act 
            var controller = new PatientsController(mockLoggerService.Object, mockWrapper.Object);
            var result = controller.GetPatientById(new Guid("03a98ce8-c141-48f6-b490-0ddba4074add")) as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetPatientById_WhenCalled_MustReturnAPatient()
        {
            var helper = new PatientHelper();
            //Arrange 
            IQueryable<Patient> patients = helper.ListOfPatients();
            Patient patient = helper.GetPatient();
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
            mockRepository.Setup(mr => mr.GetPatientById(new Guid("03a98ce8-c141-48f6-b490-0ddba4074add"))).Returns(patient);
            var mockWrapper = new Mock<IRepositoryWrapper>();
            mockWrapper.Setup(mw => mw.Patient).Returns(mockRepository.Object);

            //Act 
            var controller = new PatientsController(mockLoggerService.Object, mockWrapper.Object);
            var result = controller.GetPatientById(new Guid("03a98ce8-c141-48f6-b490-0ddba4074add")) as OkObjectResult;
            var patientResult = result.Value as Patient;
            
            //Assert
            Assert.Equal("marry@mail.com", patientResult.Email);
        }       

        [Fact]
        public void CreatePatient_WhenExecuted_MustCreateAPatient()
        {
            var helper = new PatientHelper();
            //Arrange 
            IQueryable<Patient> patients = helper.ListOfPatients();
            Patient patient = helper.CreatePatient();
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
            mockRepository.Setup(mr => mr.CreatePatient(patient)).Returns(true);
            var mockWrapper = new Mock<IRepositoryWrapper>();
            mockWrapper.Setup(mw => mw.Patient).Returns(mockRepository.Object);
            var controller = new PatientsController(mockLoggerService.Object, mockWrapper.Object);

            //Act
            var result = controller.CreatePatient(patient) as CreatedAtRouteResult;
            var item = result.Value as Patient;

            Assert.IsType<Patient>(item);
        }

    }
}
