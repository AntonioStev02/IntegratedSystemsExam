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
    public class PatientServiceImpl : IPatientService
    {
        private readonly IRepository<Patient> _patientRepository;

        public PatientServiceImpl(IRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Patient CreateNewPatient(Patient patient)
        {
            return _patientRepository.Insert(patient);
        }

        public Patient DeletePatient(Guid id)
        {
            var patient = this.GetPatientById(id);
            return _patientRepository.Delete(patient);

        }

        public Patient GetPatientById(Guid? id)
        {
            return _patientRepository.Get(id);
        }

        public List<Patient> GetPatients()
        {
            return _patientRepository.GetAll().ToList();
        }

        public Patient UpdatePatient(Patient patient)
        {
            return _patientRepository.Update(patient);
        }
    }
}
