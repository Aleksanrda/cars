using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Core.Repositories
{
    public interface IUnitOfWork
    {
        ICarRepository Cars { get; }
    }
}
