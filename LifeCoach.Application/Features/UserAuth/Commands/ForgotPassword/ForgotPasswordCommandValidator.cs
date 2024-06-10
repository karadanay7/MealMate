﻿using FluentValidation;

namespace LifeCoach.Application;

 public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
    {
        public ForgotPasswordCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                                  .EmailAddress().WithMessage("Email is not valid");
        }
    }