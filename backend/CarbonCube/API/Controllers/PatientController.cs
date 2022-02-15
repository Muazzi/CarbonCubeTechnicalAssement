using BLL.Request;
using BLL.Services;
using DLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    
    public class PatientController : MainController
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }


        [HttpGet]
   
        public ActionResult GetAllPatients()
        {
            return Ok(_patientService.GetAllPatients());
        }
        [HttpGet("{email}")]
        public async Task<ActionResult> GetAPatient(string email)
        {
            return Ok(await _patientService.GetPatientAsync(email));
        }
        [HttpPut("{email}")]
        public async Task<ActionResult> PutPatient(string email, Patient patient)
        {
            return Ok(await _patientService.UpdateAsync(email,patient));
        }

        [HttpDelete("{email}")]
        public async Task<ActionResult> DeletePatient(string email)

        {
            return Ok(await _patientService.DeletetAsync(email));
        }

        [HttpPost]
        public async Task<ActionResult> PostDepartment( [FromBody]PatientInsertRequestViewModel patient)
        {
            return Ok(await _patientService.InsertAsync(patient));
        }
    }
}
