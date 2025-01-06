using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Repository.Interface;
using IntegratedSystems.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Service.Implementation
{
    public class VaccinationCenterServiceImpl : IVaccinationCenterService
    {
        private readonly IRepository<VaccinationCenter> _vaccCenterRepository;

        public VaccinationCenterServiceImpl(IRepository<VaccinationCenter> vaccCenterRepository)
        {
            _vaccCenterRepository = vaccCenterRepository;
        }

        public void Capacity(VaccinationCenter vaccinationCenter)
        {
            --vaccinationCenter.MaxCapacity;
        }

        public VaccinationCenter CreateNewVaccinationCenter(VaccinationCenter vaccCenter)
        {
            return _vaccCenterRepository.Insert(vaccCenter);
        }

        public VaccinationCenter DeleteVaccinationCenter(Guid id)
        {
            var vaccCenter = this.GetVaccinationCenterById(id);
            return _vaccCenterRepository.Delete(vaccCenter);

        }

        public VaccinationCenter GetVaccinationCenterById(Guid? id)
        {

            return _vaccCenterRepository.Get(id);

        }

        public List<VaccinationCenter> GetVaccinationCenters()
        {
            return _vaccCenterRepository.GetAll().ToList();
        }

        public VaccinationCenter UpdateVaccinationCenter(VaccinationCenter vaccCenter)
        {
            return _vaccCenterRepository.Update(vaccCenter);
        }
    }
}
