using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BLL.Request
{
   public class PatientInsertRequestViewModel
    {
        public string FullName { get; set; }
        public string? MedicalAidName { get; set; }
        public string? MedicalAidNumber { get; set; }
        public string Email { get; set; }
        public int ?  MedicalClaimId { get; set; }
    }

    public class PatientInsertRequestViewModelValidator : AbstractValidator<PatientInsertRequestViewModel>
    {
        //private readonly IServiceProvider _serviceProvider;

        public PatientInsertRequestViewModelValidator()
        {
            //_serviceProvider = serviceProvider;
            RuleFor(x => x.FullName).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(x => x.MedicalAidNumber).MaximumLength(9).MaximumLength(9);
            //RuleFor(x => x.MedicalClaimId).GreaterThan(0).MustAsync(DepartmentExist).WithMessage("This claim already exists in the system");



        }

    }
}
