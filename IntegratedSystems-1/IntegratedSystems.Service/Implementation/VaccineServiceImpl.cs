using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Domain.DTO;
using IntegratedSystems.Repository.Interface;
using IntegratedSystems.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Service.Implementation
{
    public class VaccineServiceImpl : IVaccineService
    {
        private readonly IRepository<Vaccine> _vaccineRepository;
        private readonly IRepository<VaccinationCenter> _vaccCenterRepository;
        public VaccineServiceImpl(IRepository<Vaccine> vaccineRepository, IRepository<VaccinationCenter> vaccCenterRepsoitory)
        {
            _vaccineRepository = vaccineRepository;
            _vaccCenterRepository = vaccCenterRepsoitory;
        }
        public void VaccinationConfirmation(VaccinationDTO dto)
        {
            Vaccine vaccine = new Vaccine();
            vaccine.Manufacturer = dto.Manufacturer;
            vaccine.DateTaken = dto.DateTaken;
            vaccine.Certificate = Guid.NewGuid();
            vaccine.Center = _vaccCenterRepository.Get(dto.VaccCenterId);
            vaccine.PatientId = dto.PatientId;
            _vaccineRepository.Insert(vaccine);
        }
    }
}
