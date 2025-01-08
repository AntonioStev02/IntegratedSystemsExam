using Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class StudentOnCourseDTO
    {
        public List<Student>? students { get; set; }
        public List<Semester>? semesters { get; set; }

        public Guid StudentId { get; set; }

        public Guid SemesterId { get; set; }
        public Student? Student { get; set; }
        public Semester? Semester { get; set; }
        public Guid CourseId { get; set; }

        public Course? Course { get; set; }

    }
}
