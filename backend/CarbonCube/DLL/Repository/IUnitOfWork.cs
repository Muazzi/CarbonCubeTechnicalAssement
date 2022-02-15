using DLL.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
   public interface IUnitOfWork
    {
        IPatientRepository PatientRepository { get; }
        IMedicalClaimRepository MedicalClaimRepository { get; }
  
        Task<bool> SaveCompletedAsync();
    }
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool disposed = false;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
 

        private IPatientRepository _patientRepository;
        private IMedicalClaimRepository _medicalClaimRepository;
   

  

        public IPatientRepository PatientRepository => _patientRepository ??= new PatientRepository(_context);
        public IMedicalClaimRepository MedicalClaimRepository => _medicalClaimRepository ??= new MedicalClaimRepository(_context);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }

        public async Task<bool> SaveCompletedAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
