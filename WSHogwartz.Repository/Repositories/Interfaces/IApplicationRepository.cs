using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSHogwartz.Models;
using WSHogwartz.Repository.Infrastructure.Interfaces;

namespace WSHogwartz.Repositories
{
    public interface IApplicationRepository : IRepository<Application>
    {
    }
}
