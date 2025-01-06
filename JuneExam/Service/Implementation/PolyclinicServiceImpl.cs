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
    public class PolyclinicServiceImpl : IPolyclinicService
    {
        private readonly IRepository<Polyclinic> _polyclinicRepository;

        public PolyclinicServiceImpl(IRepository<Polyclinic> polyclinicRepository)
        {
            _polyclinicRepository = polyclinicRepository;
        }

        public Polyclinic CreateNewPolyclinic(Polyclinic polyclinic)
        {
            return _polyclinicRepository.Insert(polyclinic);
        }

        public Polyclinic DeletePolyclinic(Guid id)
        {
            var polyclinic = this.GetPolyclinicById(id);
            return _polyclinicRepository.Delete(polyclinic);

        }

        public Polyclinic GetPolyclinicById(Guid? id)
        {
            return _polyclinicRepository.Get(id);
        }

        public List<Polyclinic> GetPolyclinics()
        {
            return _polyclinicRepository.GetAll().ToList();
        }

        public void LowCapacity(Polyclinic polyclinic)
        {
            --polyclinic.AvailableSlots;
        }

        public Polyclinic UpdatePolyclinic(Polyclinic polyclinic)
        {
            return _polyclinicRepository.Update(polyclinic);
        }
    }
}
