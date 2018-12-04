using System;
using System.Collections.Generic;
using System.Text;
using Dokio.Entities.Models;
using Microsoft;
using Microsoft.EntityFrameworkCore;

namespace Dokio.Entities.Context
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        { }

        public virtual DbSet<Patient> Patients { get; set; }

    }
}
