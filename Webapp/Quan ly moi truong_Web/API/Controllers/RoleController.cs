using Application.Role.Common;
using Application.Role.Queries.List;
using Contract.Role;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllHeaders")]
    public class RoleController : ApiController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public RoleController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ListRole()
        {
            ErrorOr<List<RoleResult>> listRole = await mediator.Send(new ListQuery());

            if(listRole.IsError)
            {
                return Problem(statusCode: StatusCodes.Status400BadRequest, title: listRole.FirstError.Description);
            }



            List<RoleResponse> roles = new List<RoleResponse>();
            foreach(var role in listRole.Value)
            {
                roles.Add(mapper.Map<RoleResponse>(role));
            }

            System.Diagnostics.Debug.WriteLine("CHECK: " + roles[0].RoleName);

            return Ok(roles);
        }

    }
}
