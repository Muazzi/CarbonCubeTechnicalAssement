using DLL.DBContext;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public interface IMedicalClaimRepository : IRepositoryBase<MedicalClaim>
    {
    }

    public class MedicalClaimRepository : RepositoryBase<MedicalClaim> , IMedicalClaimRepository
    {
        public MedicalClaimRepository(ApplicationDbContext applicationDbContext): base(applicationDbContext)
        {

        }
    }
}
