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

namespace Web.Controllers
{
    public class PolyclinicsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPolyclinicService _polyclinicService;

        public PolyclinicsController(ApplicationDbContext context, IPolyclinicService polyclinicService)
        {
            _context = context;
            _polyclinicService = polyclinicService;
        }

        // GET: Polyclinics
        public async Task<IActionResult> Index()
        {
            return View(_polyclinicService.GetPolyclinics());
        }

        // GET: Polyclinics/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var polyclinic = _polyclinicService.GetPolyclinicById(id);
            if (polyclinic == null)
            {
                return NotFound();
            }

            return View(polyclinic);
        }

        // GET: Polyclinics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Polyclinics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PolyclinicName,PolyclinicAddress,Reputation,AvailableSlots,Id")] Polyclinic polyclinic)
        {
            if (ModelState.IsValid)
            {
                _polyclinicService.CreateNewPolyclinic( polyclinic);
                return RedirectToAction(nameof(Index));
            }
            return View(polyclinic);
        }

        // GET: Polyclinics/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var polyclinic = _polyclinicService.GetPolyclinicById(id);
            if (polyclinic == null)
            {
                return NotFound();
            }
            return View(polyclinic);
        }

        // POST: Polyclinics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PolyclinicName,PolyclinicAddress,Reputation,AvailableSlots,Id")] Polyclinic polyclinic)
        {
            if (id != polyclinic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _polyclinicService.UpdatePolyclinic(polyclinic);
                return RedirectToAction(nameof(Index));
            }
            return View(polyclinic);
        }

        // GET: Polyclinics/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var polyclinic = _polyclinicService.GetPolyclinicById(id);
            if (polyclinic == null)
            {
                return NotFound();
            }

            return View(polyclinic);
        }

        // POST: Polyclinics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _polyclinicService.DeletePolyclinic(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PolyclinicExists(Guid id)
        {
            return _polyclinicService.GetPolyclinicById(id) != null;
        }
    }
}
