using System;
using System.Collections.Generic;
using System.Text;

namespace Dokio.Entities.Extensions
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
