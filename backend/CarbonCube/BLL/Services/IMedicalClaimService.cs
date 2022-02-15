//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

//using System.IO;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using Microsoft.Extensions.Configuration;
//using BLL.Response;
//using IdentityModel.Client;
//using DLL.Models;
//using DLL.Repository;
//using Utilities.Exceptions;

//namespace BLL.Services
//{
//    public interface IPMedicalClaimService
//    {
//        //Task<Patient> InsertAsync(PatientInsertRequestViewModel request);
//        Task<MedicalClaim> DeletetAsync(string medicalAidNumber);
//        Task<MedicalClaim> UpdateAsync(string medicalAidNumber, MedicalClaim medicalClaim);
//        Task<MedicalClaim> GetPatientAsync(string medicalAidNumber);
//        IQueryable<Patient> GetAllStudentsAsync();
//    }

//    public class MedicalClaimService : IPMedicalClaimService
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        public MedicalClaimService(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;

//        }

//        public async Task<MedicalClaim> DeletetAsync(string medicalAidNumber)
//        {
//            var patient = await _unitOfWork.PatientRepository.FindSingleAsync(x => x.MedicalAidNumber == medicalAidNumber);
//            if (patient == null)
//            {
//                throw new ApplicationValidationException($"{ medicalAidNumbe} for the patient does not exist");
//            }

//            _unitOfWork.PatientRepository.Delete(patient);

//            if (await _unitOfWork.SaveCompletedAsync())
//            {
//                return patient;
//            }
//            throw new ApplicationValidationException(message: "Problem occured while deleating the patient record");

//        }

//        public IQueryable<Patient> GetAllStudentsAsync()
//        {
//            return _unitOfWork.PatientRepository.QueryAll();
//        }

//        public async Task<Patient> GetPatientAsync(string email)
//        {
//            var patient = await _unitOfWork.PatientRepository.FindSingleAsync(x => x.Email == email);
//            if (patient == null)
//            {
//                throw new ApplicationValidationException($"{email} for the patient does not exist");
//            }
//            return patient;
//        }

//        public async Task<Patient> UpdateAsync(string email, Patient patient)
//        {
//            var aPatient = await _unitOfWork.PatientRepository.FindSingleAsync(x => x.Email == email);
//            if (aPatient == null)
//            {
//                throw new ApplicationValidationException("Patient not found");
//            }

//            if (!string.IsNullOrWhiteSpace(patient.Email))
//            {
//                var exisitng = await _unitOfWork.PatientRepository.FindSingleAsync(x => x.Email == patient.Email);
//                if (exisitng != null)
//                {
//                    throw new ApplicationValidationException("You are updating a patient which already exists");
//                }

//                aPatient.Email = patient.Email;

//            }

//            if (!string.IsNullOrWhiteSpace(patient.FullName))
//            {
//                var exisitng = await _unitOfWork.PatientRepository.FindSingleAsync(x => x.FullName == patient.FullName);
//                if (exisitng != null)
//                {
//                    throw new ApplicationValidationException("You are updating a patient name which already exists");
//                }

//                aPatient.FullName = patient.FullName;

//            }

//            _unitOfWork.PatientRepository.Update(aPatient);
//            if (await _unitOfWork.SaveCompletedAsync())
//            {
//                return aPatient;
//            }
//            throw new ApplicationValidationException(message: "Problem occured while updating  the patient");
//        }
//    }
//}
