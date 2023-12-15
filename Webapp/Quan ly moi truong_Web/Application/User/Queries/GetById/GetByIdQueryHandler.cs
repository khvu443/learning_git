using Application.Common.Interfaces.Persistence;
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
    public class GetByIdQueryHandler
        : IRequestHandler<GetByIdQuery, ErrorOr<UserResult>>
    {
        private readonly IUserRepository userRepository;

        public GetByIdQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<ErrorOr<UserResult>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return new UserResult(userRepository.GetById(request.id));
        }
    }
}
