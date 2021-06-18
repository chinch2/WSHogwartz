using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSHogwartz.Models;
using WSHogwartz.Repositories;
using WSHogwartz.Repository.Infrastructure.Interfaces;

namespace WSHogwartz.Repository.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Applications = new ApplicationRepository(_context);
        }
        public IApplicationRepository Applications { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
