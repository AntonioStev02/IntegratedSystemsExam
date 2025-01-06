using Domain.Domain_Models;
using Domain.DTO;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class HealthExaminationServiceImpl : IHealthExaminationService
    {
        private readonly IRepository<HealthExamination> _heRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Polyclinic> _polyclinicRepository;
        public HealthExaminationServiceImpl(IRepository<HealthExamination> heRepository, IRepository<Employee> employeeRepository, IRepository<Polyclinic> polyclinicRepository)
        {
            _heRepository = heRepository;
            _employeeRepository = employeeRepository;
            _polyclinicRepository = polyclinicRepository;
        }
        public void ConfirmExam(HealthExameDTO dto)
        {
            HealthExamination he = new HealthExamination();
            he.Description = dto.Description;
            he.DateTaken = dto.DateTaken;
            he.EmployeeId = dto.EmployeeId;
            he.PolyclinicId = dto.PolyclinicId;
            he.Polyclinic = _polyclinicRepository.Get(dto.PolyclinicId);
            he.Employee = dto.Employee;
           
            _heRepository.Insert(he);
        }
    }
}
