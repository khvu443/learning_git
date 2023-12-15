using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Queries.Login
{
    /// <summary>
    /// Setup rule for login request
    /// </summary>
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(x => x.Phone).NotEmpty()
                .Length(10)
                .Matches("(03|05|07|08|09|01[2|6|8|9])+([0-9]{8})"); // check regex phone vietnam
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
