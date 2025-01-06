using IntegratedSystems.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Domain.DTO
{
    public class VaccinationDTO
    {
        public List<Patient>? patients { get; set; }
        public List<String>? manufacturers { get; set; }
        public string? Manufacturer { get; set; }
        public Guid? Certificate { get; set; }
        public DateTime DateTaken { get; set; }
        public Guid PatientId { get; set; }
        public Guid VaccCenterId { get; set; }
        public VaccinationCenter? Center { get; set; }
    }
}
