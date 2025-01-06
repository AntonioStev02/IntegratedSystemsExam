using Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IPolyclinicService
    {
        public List<Polyclinic> GetPolyclinics();
        public Polyclinic GetPolyclinicById(Guid? id);
        public Polyclinic CreateNewPolyclinic( Polyclinic polyclinic);
        public Polyclinic UpdatePolyclinic(Polyclinic polyclinic);
        public Polyclinic DeletePolyclinic(Guid id);

        public void LowCapacity(Polyclinic polyclinic);

    }
}
