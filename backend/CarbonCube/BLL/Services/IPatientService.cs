using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using BLL.Response;
using IdentityModel.Client;
using DLL.Models;
using DLL.Repository;
using Utilities.Exceptions;
using BLL.Request;

namespace BLL.Services
{
    public interface IPatientService
    {
        Task<Patient> InsertAsync(PatientInsertRequestViewModel request);
        Task<Patient> DeletetAsync(string email);
        Task<Patient> UpdateAsync(string email, Patient patient);
        Task<Patient> GetPatientAsync(string email);
        IQueryable<Patient> GetAllPatients();
    }

    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<Patient> DeletetAsync(string email)
        {
            var patient = await _unitOfWork.PatientRepository.FindSingleAsync(x => x.Email == email);
            if (patient == null)
            {
                throw new ApplicationValidationException($"{email} for the patient does not exist");
            }

            _unitOfWork.PatientRepository.Delete(patient);

            if (await _unitOfWork.SaveCompletedAsync())
            {
                return patient;
            }
            throw new ApplicationValidationException(message: "Problem occured while deleating the patient record");

        }

        public IQueryable<Patient> GetAllPatients()
        {
            return _unitOfWork.PatientRepository.QueryAll();
        }

        public async Task<Patient> GetPatientAsync(string email)
        {
            var patient = await _unitOfWork.PatientRepository.FindSingleAsync(x => x.Email == email);
            if (patient == null)
            {
                throw new ApplicationValidationException($"{email} for the patient does not exist");
            }
            return patient;
        }

        public async Task<Patient> InsertAsync(PatientInsertRequestViewModel request)
        {
            var thePatient = new Patient()
            {
                FullName = request.FullName,
                Email = request.Email,
                MedicalAidName = request.MedicalAidName,
                MedicalAidNumber = request.MedicalAidNumber,
                MedicalClaimId = request.MedicalClaimId
            };

            await _unitOfWork.PatientRepository.CreateAsync(thePatient);
            if (await _unitOfWork.SaveCompletedAsync())
            {
                return thePatient;
            }
            throw new ApplicationValidationException("Problem occured while inserting Patient record");
        }

        public async Task<Patient> UpdateAsync(string email, Patient patient)
        {
            var aPatient = await _unitOfWork.PatientRepository.FindSingleAsync(x => x.Email == email);
            if (aPatient == null)
            {
                throw new ApplicationValidationException("Patient not found");
            }

            if (!string.IsNullOrWhiteSpace(patient.Email))
            {
                var exisitng = await _unitOfWork.PatientRepository.FindSingleAsync(x => x.Email == patient.Email);
                if (exisitng != null)
                {
                    throw new ApplicationValidationException("You are updating a patient which already exists");
                }

                aPatient.Email = patient.Email;

            }

            if (!string.IsNullOrWhiteSpace(patient.FullName))
            {
                var exisitng = await _unitOfWork.PatientRepository.FindSingleAsync(x => x.FullName == patient.FullName);
                if (exisitng != null)
                {
                    throw new ApplicationValidationException("You are updating a patient name which already exists");
                }

                aPatient.FullName = patient.FullName;

            }

            _unitOfWork.PatientRepository.Update(aPatient);
            if (await _unitOfWork.SaveCompletedAsync())
            {
                return aPatient;
            }
            throw new ApplicationValidationException(message: "Problem occured while updating  the patient");
        }
    }
}
