using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Queries.GetById
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty();
        }
    }
}
