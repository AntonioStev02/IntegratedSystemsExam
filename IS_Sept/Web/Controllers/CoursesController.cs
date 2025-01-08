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
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly ISemesterService _semesterService;
        private readonly IStudentOnCourseService _scService;
        public CoursesController(ApplicationDbContext context, ICourseService courseService, IStudentService studentService, ISemesterService semesterService, IStudentOnCourseService scService)
        {
            _context = context;
            _courseService = courseService;
            _studentService = studentService;
            _semesterService = semesterService;
            _scService = scService;
        }


        public IActionResult AddStudent(Guid id)
        {
            StudentOnCourseDTO dto = new StudentOnCourseDTO();
            dto.students = _studentService.GetStudents();
            dto.CourseId = id;
            dto.semesters = _semesterService.GetSemesters();
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmStudent(StudentOnCourseDTO dto)
        {
            var course = _courseService.GetCourseById(dto.CourseId);
            if (ModelState.IsValid)
            {
                if(course.AavailableSlots <=0)
                {
                    return View("NoFreeSpace");
                }
                _courseService.FreeSpace(course);
               _scService.ConfirmStudent(dto);
                
            }

                return RedirectToAction(nameof(Index));
        }


        // GET: Courses
        public async Task<IActionResult> Index()
        {
            return View(_courseService.GetCourses());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseCode,CourseName,AavailableSlots,Id")] Course course)
        {
            if (ModelState.IsValid)
            {
                _courseService.CreateNewCourse(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CourseCode,CourseName,AavailableSlots,Id")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _courseService.UpdateCourse(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _courseService.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(Guid id)
        {
            return _courseService.GetCourseById(id) != null;
        }
    }
}
