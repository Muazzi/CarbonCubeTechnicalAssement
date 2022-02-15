using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
   public class MedicalClaim
    {
        public int MedicalClaimId { get; set; }
        public string ICDCode { get; set; }
        public string Diagnoses { get; set; }
        public double Value { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
