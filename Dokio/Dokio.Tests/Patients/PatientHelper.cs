using Dokio.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dokio.Tests.Patients
{
    public class PatientHelper
    {
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

        public Patient GetPatient()
        {
            return new Patient()
            {
                Id = new Guid("03a98ce8-c141-48f6-b490-0ddba4074add"),
                FirstName = "Marry",
                Surname = "Anne",
                Email = "marry@mail.com",
                IdNumber = "0000000000000",
                DOB = "000000",
                Gender = "Female",
                AddressLine1 = "1",
                AddressLine2 = "Rail 2",
                AddressLine3 = "5005",
                City = "M-City",
                PostCode = "1234568",
                GlobalKey = "ab2bd817",
                Cellphone = "0587456123",
                CreateUserId = 1,
                CreateDate = DateTime.Now.Date,
                ModifyUserId = 1,
                ModifyDate = DateTime.Now.Date,
                StatusId = 1
            };
        }

        public Patient CreatePatient()
        {
            return new Patient()
            {
                Id = new Guid("03a98cf8-c141-47f6-b490-0ddbb4074add"),
                FirstName = "Kenneth",
                Surname = "Brown",
                Email = "KennethB@mail.com",
                IdNumber = "0000000000000",
                DOB = "000000",
                Gender = "Male",
                AddressLine1 = "1",
                AddressLine2 = "Rail 2",
                AddressLine3 = "5005",
                City = "M-City",
                PostCode = "1234568",
                GlobalKey = "ab2bd800",
                Cellphone = "0587456331",
                CreateUserId = 1,
                CreateDate = DateTime.Now.Date,
                ModifyUserId = 1,
                ModifyDate = DateTime.Now.Date,
                StatusId = 1
            };
        }
    }
}
