using Hackaton.Application.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Hackaton.Domain.Interfaces;

namespace Hackaton.Application.Validators
{
    public class UserLoginValidator : AbstractValidator<UserLoginRequestDto>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.Email)
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                    .WithMessage("E-mail inválido.");

            RuleFor(x => x.Password)
                .MinimumLength(8)
                    .WithMessage("Formato de senha inválido: é necessário no mínimo 8 caracteres.");
        }
    }
}