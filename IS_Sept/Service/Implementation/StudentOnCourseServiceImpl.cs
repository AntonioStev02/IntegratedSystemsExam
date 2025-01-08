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
    public class StudentOnCourseServiceImpl : IStudentOnCourseService
    {
        private readonly IRepository<StudentOnCourse> _studentCourseRepo;

        public StudentOnCourseServiceImpl(IRepository<StudentOnCourse> studentCourseRepo)
        {
            _studentCourseRepo = studentCourseRepo;
        }

        public void ConfirmStudent(StudentOnCourseDTO dto)
        {
            StudentOnCourse st = new StudentOnCourse();
            st.StudentId = dto.StudentId;
            st.CourseId = dto.CourseId;
            st.SemesterId = dto.SemesterId;
            st.Student = dto.Student;
            st.Semester = dto.Semester;
            st.Course = dto.Course;
            _studentCourseRepo.Insert(st);
        }
    }
}
