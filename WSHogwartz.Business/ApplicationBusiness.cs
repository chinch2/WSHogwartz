using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSHogwartz.Business.Interfaces;
using WSHogwartz.Domain.Models;
using WSHogwartz.Models;
using WSHogwartz.Repository.Infrastructure.Interfaces;

namespace WSHogwartz.Business
{
    public class ApplicationBusiness : IApplicationBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ApplicationBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApplicationDomain> CreateApplicationAsync(ApplicationDomain applicationDom)
        {
            try
            {
                var application = _mapper.Map<Application>(applicationDom);
                var newApplication = await _unitOfWork.Applications.CreateAsync(application);
                var result = await _unitOfWork.CompleteAsync();

                if (result <= 0)
                    throw new Exception("No se pudo crear la nueva aplicación.");

                var newApplicationDom = _mapper.Map<ApplicationDomain>(newApplication);

                return newApplicationDom;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteApplicationAsync(int id)
        {
            try
            {
                await _unitOfWork.Applications.DeleteAsync(id);
                var result = await _unitOfWork.CompleteAsync();

                if (result <= 0)
                    throw new Exception("No se pudo eliminar la aplicación.");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ApplicationDomain>> GetAllApplicationsAsync()
        {
            var applications = await _unitOfWork.Applications.GetAsync();
            var applicationsDom = _mapper.Map<IEnumerable<ApplicationDomain>>(applications);

            return applicationsDom;
        }

        public async Task<ApplicationDomain> GetSingleApplicationAsync(int id)
        {
            var application = await _unitOfWork.Applications.GetAsync(id);
            var applicationDom = _mapper.Map<ApplicationDomain>(application);

            return applicationDom;
        }

        public async Task UpdateApplicationAsync(ApplicationDomain applicationDom)
        {
            try
            {
                var application = _mapper.Map<Application>(applicationDom);
                await _unitOfWork.Applications.UpdateAsync(application);
                var result = await _unitOfWork.CompleteAsync();

                if (result <= 0)
                    throw new Exception("No se pudo actualizar la aplicación.");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}