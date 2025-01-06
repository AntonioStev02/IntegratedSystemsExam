using Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IEmployeeService
    {
        public List<Employee> GetEmployees();
        public Employee GetEmployeeById(Guid? id);
        public Employee CreateNewEmployee( Employee employee);
        public Employee UpdateEmployee(Employee employee);
        public Employee DeleteEmployee(Guid id);

    }
}
