using Application.Role.Common;
using Contract.Role;
using Infrastructure.Persistence.Repositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Mapping
{
    public class RoleMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RoleResult, RoleResponse>()
                .Map(dest => dest, src => src.role);
        }
    }
}
