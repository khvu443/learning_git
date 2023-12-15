using Application.Common.Interfaces.Persistence;
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
    public class ListQueryHandler
        : IRequestHandler<ListQuery, ErrorOr<List<RoleResult>>>
    {

        private readonly IRoleRepository roleRepository;

        public ListQueryHandler(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public async Task<ErrorOr<List<RoleResult>>> Handle(ListQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            List<RoleResult> roleResults = new List<RoleResult>();
            var ls = roleRepository.GetRoles();

            foreach (var r in ls)
            {
                roleResults.Add(new RoleResult(r));
            }

            return roleResults;

        }
    }
}
