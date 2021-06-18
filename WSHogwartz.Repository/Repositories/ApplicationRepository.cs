using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSHogwartz.Models;
using WSHogwartz.Repository.Infrastructure;

namespace WSHogwartz.Repositories
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
