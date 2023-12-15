﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Commands.Add
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty()
                .Length(10)
                .Matches("(03|05|07|08|09|01[2|6|8|9])+([0-9]{8})"); // check regex phone vietnam
            RuleFor(x => x.Password).NotEmpty()
                .MinimumLength(8).MaximumLength(16)
                .Matches(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{8,16}"); // regex password have length from 8 -> 16, must have at least 1 lower and upper character, 1 number and 1 special character
            RuleFor(x => x.Image).NotEmpty();
            RuleFor(x =>x.RoleId).NotEmpty();
        }
    }
}
