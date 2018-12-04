using Dokio.Contracts.IPatient;
using Dokio.Contracts.IRepositoryWrapper;
using Dokio.Entities.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dokio.Tests
{
    public class RepositoryWrapperFake : IRepositoryWrapper
    {
        private readonly RepositoryContext _context;


        public RepositoryWrapperFake(RepositoryContext context)
        {
            _context = context;
        } 
        public IPatientRepository Patient => throw new NotImplementedException();
    }
}
