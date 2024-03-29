﻿using FluentValidation;

namespace Application.User.Commands.Udpate
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty()
                .Length(10)
                .Matches("(03|05|07|08|09|01[2|6|8|9])+([0-9]{8})"); // check regex phone vietnam
            RuleFor(x => x.Password).NotEmpty()
                .MinimumLength(8).MaximumLength(16)
                .Matches(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{8,16}"); // regex password have length from 8 -> 16, must have at least 1 lower and upper character, 1 number and 1 special character
            RuleFor(x => x.Role).NotEmpty();
            RuleFor(x => x.Image).NotEmpty();
        }
    }
}