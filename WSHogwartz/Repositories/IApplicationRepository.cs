using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSHogwartz.Models;

namespace WSHogwartz.Repositories
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<Application>> Get();
        Task<Application> Get(int id);
        Task<Application> Create(Application application);
        Task Update(Application application);
        Task Delete(int id);
    }
}
