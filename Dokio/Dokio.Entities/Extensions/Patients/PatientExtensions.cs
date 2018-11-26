using Dokio.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dokio.Entities.Extensions.Patients
{
    public static class PatientExtensions
    {
        public static void Map(this Patient dbPatient, Patient patient) {

            dbPatient.FirstName = patient.FirstName;
            dbPatient.Surname = patient.Surname;
            dbPatient.Email = patient.Email;
            dbPatient.Cellphone = patient.Cellphone;
            dbPatient.IdNumber = patient.IdNumber;
            dbPatient.DOB = patient.DOB;
            dbPatient.Gender = patient.Gender;
            dbPatient.GlobalKey = patient.GlobalKey;
            dbPatient.AddressLine1 = patient.AddressLine1;
            dbPatient.AddressLine2 = patient.AddressLine2;
            dbPatient.AddressLine3 = patient.AddressLine3;
            dbPatient.City = patient.City;
            dbPatient.PostCode = patient.PostCode;
            dbPatient.CreateUserId = patient.CreateUserId;
            dbPatient.CreateDate = patient.CreateDate;
            dbPatient.ModifyUserId = patient.ModifyUserId;
            dbPatient.ModifyDate = patient.ModifyDate;
            dbPatient.StatusId = patient.StatusId;
        }
    }
}
