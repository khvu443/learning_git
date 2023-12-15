using Application.Role.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Role.Queries.List
{
    public record ListQuery : IRequest<ErrorOr<List<RoleResult>>>;
}
