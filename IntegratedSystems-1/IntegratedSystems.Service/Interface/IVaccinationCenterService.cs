using IntegratedSystems.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Service.Interface
{
    public interface IVaccinationCenterService
    {
        public List<VaccinationCenter> GetVaccinationCenters();
        public VaccinationCenter GetVaccinationCenterById(Guid? id);
        public VaccinationCenter CreateNewVaccinationCenter( VaccinationCenter vaccCenter);
        public VaccinationCenter UpdateVaccinationCenter(VaccinationCenter vaccCenter);
        public VaccinationCenter DeleteVaccinationCenter(Guid id);
        public void Capacity(VaccinationCenter vaccinationCenter);

    }
}
