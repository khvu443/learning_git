using Application.User.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Queries.GetById
{
    public record GetByIdQuery 
    (
        Guid id
    ) : IRequest<ErrorOr<UserResult>>;
}
