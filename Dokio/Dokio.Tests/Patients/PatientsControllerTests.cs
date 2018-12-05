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
            var controller = new PatientsController(mockLoggerService.Object, mockWrapper.Object);
            var result = controller.GetAllPatients();


            //Assert
            var okObjectResults = result as OkObjectResult;
            Assert.NotNull(okObjectResults);

            var patientsList = okObjectResults.Value;
            Assert.NotNull(patientsList);
        }           


        public IQueryable<Patient> ListOfPatients()
        {
           var _patients = new List<Patient>()
            {
                new Patient() {
                    Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    FirstName ="FakeJon",
                    Surname = "FakeDoe",
                    Email = "FakeJon@mail.com",
                    IdNumber = "0000000000000" ,
                    DOB ="000000", Gender ="Male",
                    AddressLine1 ="1",
                    AddressLine2 ="Main 2",
                    AddressLine3 ="300",
                    City ="M-City",
                    PostCode ="1234568",
                    GlobalKey ="cce1d13f",
                    Cellphone ="0987456123",
                    CreateUserId =1,
                    CreateDate = DateTime.Now.Date,
                    ModifyUserId = 1,
                    ModifyDate = DateTime.Now.Date,
                    StatusId = 1},
                 new Patient() {
                    Id = new Guid("fc31c904-ea43-42e3-826b-b2313e0b4d68"),
                    FirstName ="King",
                    Surname = "Shine",
                    Email = "kingshine@mail.com",
                    IdNumber = "0000000000000" ,
                    DOB ="000000", Gender ="Male",
                    AddressLine1 ="1",
                    AddressLine2 ="Rail 2",
                    AddressLine3 ="5005",
                    City ="M-City",
                    PostCode ="1234568",
                    GlobalKey ="53ea0cd9c200",
                    Cellphone ="0587456123",
                    CreateUserId =1,
                    CreateDate = DateTime.Now.Date,
                    ModifyUserId = 1,
                    ModifyDate = DateTime.Now.Date,
                    StatusId = 1},
                  new Patient() {
                    Id = new Guid("03a98ce8-c141-48f6-b490-0ddba4074add"),
                    FirstName ="Marry",
                    Surname = "Anne",
                    Email = "marry@mail.com",
                    IdNumber = "0000000000000" ,
                    DOB ="000000", Gender ="Female",
                    AddressLine1 ="1",
                    AddressLine2 ="Rail 2",
                    AddressLine3 ="5005",
                    City ="M-City",
                    PostCode ="1234568",
                    GlobalKey ="ab2bd817",
                    Cellphone ="0587456123",
                    CreateUserId =1,
                    CreateDate = DateTime.Now.Date,
                    ModifyUserId = 1,
                    ModifyDate = DateTime.Now.Date,
                    StatusId = 1},
            }.AsQueryable();

            return _patients;
        }
    }
}
