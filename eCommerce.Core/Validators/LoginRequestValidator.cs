using eCommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{

    public LoginRequestValidator()
    {
        RuleFor(temp => temp.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid Email address format");

        RuleFor(temp => temp.Password)
            .NotEmpty().WithMessage("Password is required")
           .MinimumLength(3).WithMessage("Your password must be more than 3 characters.");


    }



}

