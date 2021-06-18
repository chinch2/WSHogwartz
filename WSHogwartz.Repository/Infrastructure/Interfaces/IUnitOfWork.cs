using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSHogwartz.Repository.Repositories.Interfaces;

namespace WSHogwartz.Repository.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationRepository Applications { get; }
        Task<int> CompleteAsync();
    }
}
