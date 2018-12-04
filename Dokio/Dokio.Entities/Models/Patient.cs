using Dokio.Entities.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dokio.Entities.Models
{
    [Table("patient")]
    public class Patient : IEntity
    {
        [Key]
        [Column("PatientId")]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string IdNumber { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string GlobalKey { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int ModifyUserId { get; set; }
        public DateTime ModifyDate { get; set; }
        public int StatusId { get; set; }
     }
}
