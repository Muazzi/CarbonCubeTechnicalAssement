using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
   public class Patient
    {
        public int PatientId { get; set; }
        public string FullName { get; set; }
        public string? MedicalAidName { get; set; }
        public string? MedicalAidNumber { get; set; }
        public string Email { get; set; }
        public MedicalClaim MedicalClaim { get; set; }

        public int? MedicalClaimId { get; set; }
    }
}
