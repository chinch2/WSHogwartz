using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSHogwartz.Repositories;

namespace WSHogwartz.Repository.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationRepository Applications { get; }
        Task<int> CompleteAsync();
    }
}
