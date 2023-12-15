using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using Domain.Entities;
using Domain.Common.Errors;
using Application.Authentication.Common;

namespace Application.Authentication.Queries.Login
{
    public class LoginQueryHandler :
        IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;


        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.roleRepository = roleRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // Check if user already exist
            if (userRepository.GetUserByPhone(query.Phone) is not Users user)
                return Errors.Authentication.InvalidCredentials;

            // Valid the password is correct
            if (user.Password != query.Password)
                return new[] { Errors.Authentication.InvalidCredentials };

            // Create JWT token
            var token = jwtTokenGenerator.GenerateToken(user, roleRepository.GetRoles());


            return new AuthenticationResult(
                        user,
                        token
                    );
        }
    }
}
