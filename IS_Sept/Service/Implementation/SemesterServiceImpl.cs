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
    public class SemesterServiceImpl : ISemesterService
    {
        private readonly IRepository<Semester> _semesterRepository;

        public SemesterServiceImpl(IRepository<Semester> semesterRepository)
        {
            _semesterRepository = semesterRepository;
        }

        public Semester CreateNewSemester(Semester semester)
        {
            return _semesterRepository.Insert(semester);
        }

        public Semester DeleteSemester(Guid id)
        {
            var semester = this.GetSemesterById(id);
            return _semesterRepository.Delete(semester);
        }

        public Semester GetSemesterById(Guid? id)
        {
            return _semesterRepository.Get(id);
           
        }

        public List<Semester> GetSemesters()
        {
            return _semesterRepository.GetAll().ToList();
        }

        public Semester UpdateSemester(Semester semester)
        {
            return _semesterRepository.Update(semester);
        }
    }
}
