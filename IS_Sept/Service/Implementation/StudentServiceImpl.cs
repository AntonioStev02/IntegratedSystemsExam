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
    public class StudentServiceImpl : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentServiceImpl(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Student CreateNewStudent(Student student)
        {
            return _studentRepository.Insert(student);
        }

        public Student DeleteStudent(Guid id)
        {
            var student = this.GetStudentById(id);
            return _studentRepository.Delete(student);
        }

        public Student GetStudentById(Guid? id)
        {
            return _studentRepository.Get(id);
        }

        public List<Student> GetStudents()
        {
            return _studentRepository.GetAll().ToList();
        }

        public Student UpdateStudent(Student student)
        {   
            return _studentRepository.Update(student);
        }
    }
}
