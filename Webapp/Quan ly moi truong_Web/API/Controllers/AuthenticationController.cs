using Contract.Authentication;
using Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Common.Errors;
using MediatR;
using Application.Authentication.Commands.Register;
using Application.Authentication.Common;
using Application.Authentication.Queries.Login;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/auth")]
    [EnableCors("AllowAllHeaders")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = mapper.Map<RegisterCommand>(request);

            ErrorOr<AuthenticationResult> authResult = await mediator.Send(command);

            return authResult.Match(
                    authResult => Ok(mapper.Map<AuthenticationResponse>(authResult)),
                    errors => Problem(errors)
                );
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = mapper.Map<LoginQuery>(request);

            ErrorOr<AuthenticationResult> authResult = await mediator.Send(query);

            if (authResult.IsError
                && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }


            return authResult.Match(
                    authResult =>
                    {
                        Response.Cookies.Append("access_token", authResult.Token, new CookieOptions()
                        {
                            IsEssential = true,
                            Expires = DateTime.Now.AddHours(3),
                            Secure = true,
                            HttpOnly = true,
                            SameSite = SameSiteMode.None
                        });

                        return Ok(mapper.Map<AuthenticationResponse>(authResult));
                    },
                    errors => Problem(errors)
                );
        }
    }
}
