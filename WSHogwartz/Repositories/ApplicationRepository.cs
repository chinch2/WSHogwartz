using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSHogwartz.Models;

namespace WSHogwartz.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationContext _context;

        public ApplicationRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Application> Create(Application application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();

            return application;
        }

        public async Task Delete(int id)
        {
            var applicationToDelete = await _context.Applications.FindAsync(id);
            _context.Applications.Remove(applicationToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Application>> Get()
        {
            return await _context.Applications.ToListAsync();
        }

        public async Task<Application> Get(int id)
        {
            return await _context.Applications.FindAsync(id);
        }

        public async Task Update(Application application)
        {
            _context.Entry(application).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
