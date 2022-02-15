using DLL.DBContext;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public interface IPatientRepository : IRepositoryBase<Patient>
    {
    }

    public class PatientRepository : RepositoryBase<Patient> , IPatientRepository
    {
        public PatientRepository(ApplicationDbContext applicationDbContext): base(applicationDbContext)
        {

        }
    }
}
