using Domain.Domain_Models;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class EmployeeServiceImpl : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeServiceImpl(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee CreateNewEmployee(Employee employee)
        {
            return _employeeRepository.Insert(employee);
        }

        public Employee DeleteEmployee(Guid id)
        {
            var employee = this.GetEmployeeById(id);
            return _employeeRepository.Delete(employee);

        }

        public Employee GetEmployeeById(Guid? id)
        {
            return _employeeRepository.Get(id);
        }

        public List<Employee> GetEmployees()
        {
            return _employeeRepository.GetAll().ToList();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            return _employeeRepository.Update(employee);
        }
    }
}
