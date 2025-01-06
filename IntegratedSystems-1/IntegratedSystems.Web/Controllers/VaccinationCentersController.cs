using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Repository;
using IntegratedSystems.Service.Interface;
using IntegratedSystems.Domain.DTO;

namespace IntegratedSystems.Web.Controllers
{
    public class VaccinationCentersController : Controller
    {
        private readonly IVaccinationCenterService _vaccCenterService;
        private readonly IPatientService _patientService;
        private readonly IVaccineService _vaccineService;
        public VaccinationCentersController(IVaccinationCenterService vaccCenterService, IPatientService patientService, IVaccineService vaccineService)
        {
            _vaccCenterService = vaccCenterService;
            _patientService = patientService;
            _vaccineService = vaccineService;
        }

        public IActionResult ScheduleVaccination(Guid id)
        {
            VaccinationDTO dto = new VaccinationDTO();
            dto.manufacturers = new List<string>()
            {
                "Sputnik","Phizer","Astra Zeneca"
            };
            dto.patients = _patientService.GetPatients();
            dto.VaccCenterId = id;

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult ConfirmSchedule(VaccinationDTO dto)
        {
            var vaccine = _vaccCenterService.GetVaccinationCenterById(dto.VaccCenterId);
            if (ModelState.IsValid)
            {
                if (vaccine.MaxCapacity <= 0)
                {
                    return View("LowCapacity");
                }
                _vaccCenterService.Capacity(_vaccCenterService.GetVaccinationCenterById(dto.VaccCenterId));
                _vaccineService.VaccinationConfirmation(dto);
               
            }
             return RedirectToAction(nameof(Index));
        }

        // GET: VaccinationCenters
        public async Task<IActionResult> Index()
        {
            return View(_vaccCenterService.GetVaccinationCenters());
        }

        // GET: VaccinationCenters/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationCenter = _vaccCenterService.GetVaccinationCenterById(id);
            if (vaccinationCenter == null)
            {
                return NotFound();
            }

            return View(vaccinationCenter);
        }

        // GET: VaccinationCenters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VaccinationCenters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Address,MaxCapacity,Id")] VaccinationCenter vaccinationCenter)
        {
            if (ModelState.IsValid)
            {
                _vaccCenterService.CreateNewVaccinationCenter( vaccinationCenter);
                return RedirectToAction(nameof(Index));
            }
            return View(vaccinationCenter);
        }

        // GET: VaccinationCenters/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationCenter = _vaccCenterService.GetVaccinationCenterById(id);
            if (vaccinationCenter == null)
            {
                return NotFound();
            }
            return View(vaccinationCenter);
        }

        // POST: VaccinationCenters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Address,MaxCapacity,Id")] VaccinationCenter vaccinationCenter)
        {
            if (id != vaccinationCenter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _vaccCenterService.UpdateVaccinationCenter(vaccinationCenter);
                return RedirectToAction(nameof(Index));
            }
            return View(vaccinationCenter);
        }

        // GET: VaccinationCenters/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationCenter = _vaccCenterService.GetVaccinationCenterById(id);
            if (vaccinationCenter == null)
            {
                return NotFound();
            }

            return View(vaccinationCenter);
        }

        // POST: VaccinationCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _vaccCenterService.DeleteVaccinationCenter(id);
            return RedirectToAction(nameof(Index));
        }

        private bool VaccinationCenterExists(Guid id)
        {
            return _vaccCenterService.GetVaccinationCenterById(id) != null;
        }
    }
}
