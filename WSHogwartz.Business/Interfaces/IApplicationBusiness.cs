using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSHogwartz.Domain.Models;

namespace WSHogwartz.Business.Interfaces
{
    public interface IApplicationBusiness
    {
        Task<IEnumerable<ApplicationDomain>> GetAllApplicationsAsync();
        Task<ApplicationDomain> GetSingleApplicationAsync(int id);
        Task<ApplicationDomain> CreateApplicationAsync(ApplicationDomain applicationDom);
        Task UpdateApplicationAsync(ApplicationDomain applicationDom);
        Task DeleteApplicationAsync(int id);
    }
}
