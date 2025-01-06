using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Domain_Models;
using Repository;
using Service.Interface;
using Domain.DTO;

namespace Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmployeeService _employeeService;
        private readonly IPolyclinicService _polyclinicService;
        private readonly IHealthExaminationService _heService;
        public EmployeesController(ApplicationDbContext context, IEmployeeService employeeService, IPolyclinicService polyclinicService, IHealthExaminationService heService)
        {
            _context = context;
            _employeeService = employeeService;
            _polyclinicService = polyclinicService;
            _heService = heService;
        }

        public IActionResult ScheduleExam(Guid id)
        {
            HealthExameDTO dto = new HealthExameDTO();
            dto.polyclinics = _polyclinicService.GetPolyclinics();
            dto.EmployeeId = id;
            dto.Employee = _employeeService.GetEmployeeById(id);
            dto.Company = _employeeService.GetEmployeeById(id).Company;           
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult ConfirmExam(HealthExameDTO dto)
        {
            var polyclinic = _polyclinicService.GetPolyclinicById(dto.PolyclinicId);
            if (ModelState.IsValid)
            {
                if(polyclinic.AvailableSlots<=0)
                {
                    return View("NoCapacity");
                }
                _polyclinicService.LowCapacity(_polyclinicService.GetPolyclinicById(dto.PolyclinicId));    
               _heService.ConfirmExam(dto);
               
            }
             return RedirectToAction(nameof(Index));
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(_employeeService.GetEmployees());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,DateOfBirth,Title,CompanyId,Id")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.CreateNewEmployee( employee);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id", employee.CompanyId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id", employee.CompanyId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FullName,DateOfBirth,Title,CompanyId,Id")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id", employee.CompanyId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _employeeService.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(Guid id)
        {
            return _employeeService.GetEmployeeById(id) != null;
        }
    }
}
