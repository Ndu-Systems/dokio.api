using Dokio.Contracts.IPatient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dokio.Contracts.IRepositoryWrapper
{
    public interface IRepositoryWrapper
    {
        IPatientRepository Patient { get; }
    }
}
