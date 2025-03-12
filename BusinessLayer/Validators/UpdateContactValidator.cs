using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ModelLayer.DTO;
namespace BusinessLayer.Validators
{
    public class UpdateContactValidator : AbstractValidator<UpdateContactDTO>
    {
        public UpdateContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid email format");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone number is required");
        }
    }
}
