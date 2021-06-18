using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSHogwartz.Repository.Infrastructure;
using WSHogwartz.Repository.Models;
using WSHogwartz.Repository.Repositories.Interfaces;

namespace WSHogwartz.Repository.Repositories
{
    public class ApplicationRepository : Repository<Application>, IApplicationRepository
    {
        public ApplicationRepository(ApplicationContext context) : base(context)
        {
        }

        public ApplicationContext ApplicationContext
        {
            get { return Context as ApplicationContext; }
        }
    }
}
