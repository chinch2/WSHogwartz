using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSHogwartz.Repository.Infrastructure.Interfaces;
using WSHogwartz.Repository.Models;

namespace WSHogwartz.Repository.Repositories.Interfaces
{
    public interface IApplicationRepository : IRepository<Application>
    {
    }
}
